using ErrorOr;
using MediatR;
using Replica.Application.Common.Interfaces.Repositories;
using Replica.Domain.AppError;
using Replica.Domain.Entities;

namespace Replica.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, ErrorOr<Guid>>
    {
        protected readonly IOrderRepository _orderRepository;
        protected readonly IProductRepository _productRepository;
        protected readonly IPlaceRepository _placeRepository;
        protected readonly IReservationRepository _reservationRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IConfirmationStatusRepository _confirmationStatusRepository;
        protected readonly IPaymentStatusRepository _paymentStatusRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IPlaceRepository placeRepository,
            IReservationRepository reservationRepository,
            IUserRepository userRepository,
            IConfirmationStatusRepository confirmationStatusRepository,
            IPaymentStatusRepository paymentStatusRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _placeRepository = placeRepository;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _confirmationStatusRepository = confirmationStatusRepository;
            _paymentStatusRepository = paymentStatusRepository;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            Order order = new()
            {
                Id = Guid.NewGuid(),
                Comment = request.Comment,
                Created = DateTime.UtcNow.Date,
                TotalCost = request.TotalCost
            };

            var confirmationStatus = await _confirmationStatusRepository
                .GetByNameAsync("Нове");
            if (confirmationStatus is null)
                return Errors.ConfirmationStatus.NotFound;
            else order.ConfirmationStatus = confirmationStatus;


            var paymentStatus = await _paymentStatusRepository
                .GetAsync(request.PaymentStatusId);
            if (paymentStatus is null)
                return Errors.PaymentStatus.NotFound;
            else order.PaymentStatus = paymentStatus;


            var user = await _userRepository.GetAsync(request.UserId);
            if (user is null) return Errors.User.NotFound;
            else order.User = user;

            if(request.Products is not null)
            {
                foreach (var productData in request.Products)
                {
                    var product = await _productRepository.GetAsync(productData.Key);

                    if (product is not null)
                        order.ProductCounts.Add(new ProductCount
                        {
                            Product = product,
                            Count = productData.Value,
                            Order = order
                        });
                }
            }


            if (request.PlaceId != Guid.Empty)
            {
                var place = await _placeRepository.GetAsync(request.PlaceId);
                if (place is null) return Errors.Place.NotFound;

                var reservationId = await _reservationRepository.CreateAsync(new Reservation
                {
                    Place = place,
                    ReservationTime = request.ReservationTime,
                });

                order.Reservation = await _reservationRepository.GetAsync(reservationId);
            }

            return await _orderRepository.CreateAsync(order);
        }
    }
}
