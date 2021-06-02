﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoContest.Data;
using PhotoContest.Data.Models;
using PhotoContest.Services.Contracts;
using PhotoContest.Services.Models.Create;
using PhotoContest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoContest.Tests.ServicesTests.ContestServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task Return_Created_Contest()
        {
            /*var options = Utils.GetOptions(nameof(Return_Created_Contest));
            var newContestDTO = new Mock<NewContestDTO>().Object;
            newContestDTO.Name = "NewestTest";
            newContestDTO.CategoryName = "Cars";
            newContestDTO.IsOpen = true;
            newContestDTO.Phase1 = DateTime.Now.AddHours(2).ToString("dd.MM.yy HH:mm");
            newContestDTO.Phase2 = DateTime.Now.AddHours(30).ToString("dd.MM.yy HH:mm");
            newContestDTO.Finished = DateTime.Now.AddHours(32).ToString("dd.MM.yy HH:mm");

            var categoryService = new Mock<ICategoryService>();
            var userService = new Mock<IUserService>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var category = new Category();
            category.Name = "Cars";
            categoryService.Setup(c => c.FindCategoryByNameAsync(newContestDTO.CategoryName)).Returns(Task.FromResult(category));

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Categories.AddAsync(category);
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.SaveChangesAsync();
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService.Object);
                var result = await sut.CreateAsync(newContestDTO);
                
                Assert.AreEqual(newContestDTO.Name, result.Name);
                Assert.AreEqual(newContestDTO.Phase1, result.Phase1);
                Assert.AreEqual(newContestDTO.Phase2, result.Phase2);
                Assert.AreEqual(newContestDTO.Finished, result.Finished);
            }*/
        }

        [TestMethod]
        public async Task ThrowsWhen_Phase1_NotCorrect()
        {
            var options = Utils.GetOptions(nameof(ThrowsWhen_Phase1_NotCorrect));
            var newContestDTO = new Mock<NewContestDTO>().Object;
            newContestDTO.Name = "NewestTest";
            newContestDTO.CategoryName = "Cars";
            newContestDTO.IsOpen = true;
            newContestDTO.Phase1 = "01.01.21 20:00";
            newContestDTO.Phase2 = DateTime.Now.AddHours(30).ToString("dd.MM.yy HH:mm");
            newContestDTO.Finished = DateTime.Now.AddHours(32).ToString("dd.MM.yy HH:mm");

            var categoryService = new Mock<ICategoryService>();
            var userService = new Mock<IUserService>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var category = new Category();
            category.Name = "Cars";
            categoryService.Setup(c => c.FindCategoryByNameAsync(newContestDTO.CategoryName)).Returns(Task.FromResult(category));

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Categories.AddAsync(category);
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.SaveChangesAsync();
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService.Object);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateAsync(newContestDTO));
            }
        }

        [TestMethod]
        public async Task ThrowsWhen_Phase2_NotCorrect()
        {
            var options = Utils.GetOptions(nameof(ThrowsWhen_Phase2_NotCorrect));
            var newContestDTO = new Mock<NewContestDTO>().Object;
            newContestDTO.Name = "NewestTest";
            newContestDTO.CategoryName = "Cars";
            newContestDTO.IsOpen = true;
            newContestDTO.Phase1 = DateTime.Now.AddHours(2).ToString("dd.MM.yy HH:mm");
            newContestDTO.Phase2 = "02.06.21 20:00";
            newContestDTO.Finished = DateTime.Now.AddHours(32).ToString("dd.MM.yy HH:mm");

            var categoryService = new Mock<ICategoryService>();
            var userService = new Mock<IUserService>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var category = new Category();
            category.Name = "Cars";
            categoryService.Setup(c => c.FindCategoryByNameAsync(newContestDTO.CategoryName)).Returns(Task.FromResult(category));

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Categories.AddAsync(category);
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.SaveChangesAsync();
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService.Object);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateAsync(newContestDTO));
            }
        }

        [TestMethod]
        public async Task ThrowsWhen_Finished_NotCorrect()
        {
            var options = Utils.GetOptions(nameof(ThrowsWhen_Finished_NotCorrect));
            var newContestDTO = new Mock<NewContestDTO>().Object;
            newContestDTO.Name = "NewestTest";
            newContestDTO.CategoryName = "Cars";
            newContestDTO.IsOpen = true;
            newContestDTO.Phase1 = DateTime.Now.AddHours(2).ToString("dd.MM.yy HH:mm");
            newContestDTO.Phase2 = DateTime.Now.AddHours(30).ToString("dd.MM.yy HH:mm");
            newContestDTO.Finished = "01.06.21 10:00";

            var categoryService = new Mock<ICategoryService>();
            var userService = new Mock<IUserService>();
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var category = new Category();
            category.Name = "Cars";
            categoryService.Setup(c => c.FindCategoryByNameAsync(newContestDTO.CategoryName)).Returns(Task.FromResult(category));

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Categories.AddAsync(category);
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.SaveChangesAsync();
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService.Object);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateAsync(newContestDTO));
            }
        }
    }
}
