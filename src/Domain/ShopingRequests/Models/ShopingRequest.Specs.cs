namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using FakeItEasy;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using ShopingRequestSystem.Domain.ShopingRequests.Exceptions;

    public class ShopingRequestSpecs
    {
        [Fact]
        public void InvalidStatusChangeFromOpenToInProgress()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Open));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.InProgress);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }

        [Fact]
        public void ValidStatusChangeFromOpenToPublished()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Open));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Published);

            // Assert
            act.Should().NotThrow<InvalidShopingRequestException>();
        }

        [Fact]
        public void ValidStatusChangeFromPublishedToOpen()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Published));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Open);

            // Assert
            act.Should().NotThrow<InvalidShopingRequestException>();
        }

        [Fact]
        public void InvalidStatusChangeFromInProgressToOpen()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.InProgress));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Open);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }

        [Fact]
        public void InvalidStatusChangeFromInProgressToPublished()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.InProgress));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Published);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }

        [Fact]
        public void InvalidStatusChangeFromInProgressToClosed()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.InProgress));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Closed);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }

        [Fact]
        public void ValidStatusChangeFromInProgressToCompleted()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.InProgress));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Completed);

            // Assert
            act.Should().NotThrow<InvalidShopingRequestException>();
        }

        [Fact]
        public void InvalidStatusChangeFromCompletedToInProgress()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Completed));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.InProgress);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }

        [Fact]
        public void ValidStatusChangeFromCompletedToClosed()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Completed));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Closed);

            // Assert
            act.Should().NotThrow<InvalidShopingRequestException>();
        }

        [Fact]
        public void InvalidStatusChangeFromClosedToCompleted()
        {
            // Arrange  
            ShopingRequest shopingRequest = A.Dummy<List<ShopingRequest>>()
                .FirstOrDefault(x => x.Status.Equals(RequestStatus.Closed));

            // Act
            Action act = () => shopingRequest.UpdateStatus(RequestStatus.Completed);

            // Assert
            act.Should().Throw<InvalidShopingRequestException>();
        }
    }
}
