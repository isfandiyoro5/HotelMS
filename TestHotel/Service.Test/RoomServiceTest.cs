using AutoMapper;
using Castle.Core.Logging;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.Services;
using Xunit;

namespace Service.Test
{
    public class RoomServiceTest
    {
        private readonly Mock<IRoomRepository> _roomRepositoryMock = new Mock<IRoomRepository>();
        private readonly Mock<ILogger<RoomService>> _loggerMock = new Mock<ILogger<RoomService>>();
        private readonly Mock<IValidator<RoomRequestDto>> _roomRequestDtoValidatorMock = new Mock<IValidator<RoomRequestDto>>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        // AddRoomAsync

        [Fact]
        public async Task AddRoomAsyncWhenCalledWithValidDataShouldReturnNewRoomId()
        {
            /// Arrange
            var roomRequestDto = new RoomRequestDto();
            var room = new Room();
            var validationResult = new ValidationResult();

            _roomRequestDtoValidatorMock.Setup(x => x.ValidateAsync(roomRequestDto, default)).ReturnsAsync(validationResult);
            _mapperMock.Setup(x => x.Map<Room>(roomRequestDto)).Returns(room);
            _roomRepositoryMock.Setup(x => x.AddRoomAsync(room)).ReturnsAsync(1);

            var roomService = new RoomService
                (_roomRepositoryMock.Object,
                _loggerMock.Object,
                _mapperMock.Object,
                _roomRequestDtoValidatorMock.Object);

            /// Act
            var result = await roomService.AddRoomAsync(roomRequestDto);

            ///Assert
            Assert.Equal(1,result);
        }

        [Fact]

        public async Task AddRoomAsyncWhenCalledWithInvalidDataShouldThrowException()
        {
            /// Arrange
            var roomRequestDto = new RoomRequestDto();
            var room = new Room();
            var validationFailures = new List<ValidationFailure>();
            var validationResult = new ValidationResult();
            _roomRequestDtoValidatorMock.Setup(x => x.ValidateAsync(roomRequestDto, default)).ReturnsAsync(validationResult);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => roomService.AddRoomAsync(roomRequestDto));
        }

        // GetRoomById

        [Fact]
        public async Task GetRoomByIdAsyncWhenCalledWithValidDataShouldReturnRoom()
        {
            // Arrange
            int roomId = 1;
            var roomResult = new Room();
            var roomResponseDtoResult = new RoomResponseDto();

            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync(roomResult);
            _mapperMock.Setup(x => x.Map<RoomResponseDto>(roomResult)).Returns(roomResponseDtoResult);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act
            var result = await roomService.GetRoomByIdAsync(roomId);

            // Assert
            Assert.Equal(roomResponseDtoResult, result);
        }
        [Fact]
        public async Task GetRoomByIdAsyncWhenCalledWithInvalidDataShouldThrowException()
        {
            // Arrange
            int roomId = 1;

            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync((Room)null);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => roomService.GetRoomByIdAsync(roomId));
        }

        // GetAllRoomsAsync

        [Fact]
        public async Task GetAllRoomsAsyncWhenCalledShouldReturnAllRooms()
        {
            // Arrange
            var rooms = new List<Room>();
            _roomRepositoryMock.Setup(x => x.GetAllRoomsAsync()).ReturnsAsync(rooms);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act
            var result = await roomService.GetAllRoomsAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task GetAllRoomsAsyncWhenCalledShouldThrowException()
        {
            // Arrange
            _roomRepositoryMock.Setup(x => x.GetAllRoomsAsync()).ThrowsAsync(new Exception());

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => roomService.GetAllRoomsAsync());
        }

        // UpdateRoomAsync

        [Fact]
        public async Task UpdateRoomAsyncWhenCalledWithValidDataShouldReturnUpdatedRoom()
        {
            // Arrange
            int roomId = 1;
            var roomRequestDto = new RoomRequestDto();
            var roomResult = new Room();

            _roomRequestDtoValidatorMock.Setup(x => x.ValidateAsync(roomRequestDto, default)).ReturnsAsync(new ValidationResult());
            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync(roomResult);
            _roomRepositoryMock.Setup(x => x.UpdateRoomAsync(roomResult)).ReturnsAsync(1);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act
            var result = await roomService.UpdateRoomAsync(roomId, roomRequestDto);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task UpdateRoomAsyncWhenCalledWithInvalidDataShouldThrowException()
        {
            // Arrange
            int roomId = 1;
            var roomRequestDto = new RoomRequestDto();

            _roomRequestDtoValidatorMock.Setup(x => x.ValidateAsync(roomRequestDto,default)).ReturnsAsync(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("test", "test") }));
            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync((Room)null);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => roomService.UpdateRoomAsync(roomId, roomRequestDto));
        }

        //DeleteRoomAsync
        [Fact]
        public async Task DeleteRoomAsyncWhenCalledWithValidDataShouldReturnDeletedRoomId()
        {
            // Arrange
            int roomId = 1;
            var roomResult = new Room();

            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync(roomResult);
            _roomRepositoryMock.Setup(x => x.DeleteRoomAsync(roomResult)).ReturnsAsync(1);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act
            var result = await roomService.DeleteRoomAsync(roomId);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task DeleteRoomAsyncWhenCalledWithInvalidDataShouldThrowException()
        {
            // Arrange
            int roomId = 1;

            _roomRepositoryMock.Setup(x => x.GetRoomByIdAsync(roomId)).ReturnsAsync((Room)null);

            var roomService = new RoomService(_roomRepositoryMock.Object, _loggerMock.Object, _mapperMock.Object, _roomRequestDtoValidatorMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => roomService.DeleteRoomAsync(roomId));
        }
    }
}