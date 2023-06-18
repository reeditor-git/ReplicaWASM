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

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IPlaceRepository placeRepository,
            IReservationRepository reservationRepository,
            IUserRepository userRepository) =>
            (_orderRepository, _productRepository, _placeRepository,
            _reservationRepository, _userRepository) =
            (orderRepository, productRepository, placeRepository,
            reservationRepository, userRepository);

        public async Task<ErrorOr<Guid>> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            Order order = new()
            {
                Comment = request.Comment,
                PaymentStatus = request.PaymentStatus,
                ConfirmationStatus = Domain.Enums.ConfirmationStatus.Нове,
                Created = DateTime.UtcNow.Date,
                TotalCost = request.TotalCost
        };

            var user = await _userRepository.GetAsync(request.UserId);

            if (user is null)
                return Errors.User.NotFound;

            order.User = user;

            if(request.ProductIds is not null)
            {
                foreach (var productId in request.ProductIds)
                {
                    var product = await _productRepository.GetAsync(productId);

                    if (product is not null)
                        order.Products.Add(product);
                }
            }

            if (request.PlaceId != Guid.Empty)
            {
                var place = await _placeRepository.GetAsync(request.PlaceId);

                if (place is null)
                    return Errors.Place.NotFound;

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
