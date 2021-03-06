using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhotoContest.Data;
using PhotoContest.Services.Contracts;
using PhotoContest.Services.Models;
using PhotoContest.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoContest.Tests.ServicesTests.ContestServiceTests
{
    [TestClass]
    public class GetByUser_Should
    {
        [TestMethod]
        public async Task Return_UserContests_All()
        {
            var options = Utils.GetOptions(nameof(Return_UserContests_All));

            var categoryService = new Mock<ICategoryService>().Object;
            var userService = new Mock<IUserService>();
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null,
                null, null, null, null, null);
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>().Object;
            var signManager = new Mock<SignInManager<User>>(userManager.Object, contextAccessor.Object, userPrincipalFactory, null, null, null, null).Object;
            var context = new Mock<HttpContext>();
            contextAccessor.Setup(a => a.HttpContext).Returns(context.Object);

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Users.AddRangeAsync(Utils.SeedUsers());
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.Categories.AddRangeAsync(Utils.SeedCategories());
                await arrContext.Photos.AddRangeAsync(Utils.SeedPhotos());
                await arrContext.Contests.AddRangeAsync(Utils.SeedContests());
                await arrContext.UserContests.AddRangeAsync(Utils.SeedUserContests());
                await arrContext.Ranks.AddRangeAsync(Utils.SeedRanks());
                await arrContext.SaveChangesAsync();

                var user = arrContext.Users.Skip(4).First();
                userManager.Setup(u => u.GetUserName(signManager.Context.User)).Returns(user.UserName);
                userService.Setup(u => u.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult(user));
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var contestToEnroll = actContext.Contests.Last();
                var user = actContext.Users.Skip(4).First();
                var allUserContests = actContext.UserContests.Where(uc => uc.UserId == user.Id);
                var allUserContestsDTO = new List<ContestDTO>();
                foreach (var userContest in allUserContests)
                {
                    var contest = await actContext.Contests
                                      .Include(c => c.Category)
                                      .Include(c => c.Status)
                                      .FirstAsync(c => c.Id == userContest.ContestId && c.IsDeleted == false);
                    allUserContestsDTO.Add(new ContestDTO(contest));
                }
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService, userManager.Object, signManager);
                var result = await sut.GetByUserAsync(null);

                Assert.AreEqual(result.Count(), allUserContestsDTO.Count());
                Assert.AreEqual(string.Join(",", allUserContestsDTO), string.Join(",", result));
            }
        }

        [TestMethod]
        public async Task Return_UserContests_Current()
        {
            var options = Utils.GetOptions(nameof(Return_UserContests_Current));

            var categoryService = new Mock<ICategoryService>().Object;
            var userService = new Mock<IUserService>();
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null,
                null, null, null, null, null);
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>().Object;
            var signManager = new Mock<SignInManager<User>>(userManager.Object, contextAccessor.Object, userPrincipalFactory, null, null, null, null).Object;
            var context = new Mock<HttpContext>();
            contextAccessor.Setup(a => a.HttpContext).Returns(context.Object);

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Users.AddRangeAsync(Utils.SeedUsers());
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.Categories.AddRangeAsync(Utils.SeedCategories());
                await arrContext.Photos.AddRangeAsync(Utils.SeedPhotos());
                await arrContext.Contests.AddRangeAsync(Utils.SeedContests());
                await arrContext.UserContests.AddRangeAsync(Utils.SeedUserContests());
                await arrContext.Ranks.AddRangeAsync(Utils.SeedRanks());
                await arrContext.SaveChangesAsync();

                var user = arrContext.Users.Skip(4).First();
                userManager.Setup(u => u.GetUserName(signManager.Context.User)).Returns(user.UserName);
                userService.Setup(u => u.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult(user));
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var contestToEnroll = actContext.Contests.Last();
                var user = actContext.Users.Skip(4).First();
                var allUserContests = actContext.UserContests.Where(uc => uc.UserId == user.Id);
                var allUserContestsDTO = new List<ContestDTO>();
                foreach (var userContest in allUserContests)
                {
                    var contest = await actContext.Contests
                                      .Include(c => c.Category)
                                      .Include(c => c.Status)
                                      .FirstAsync(c => c.Id == userContest.ContestId && c.IsDeleted == false);
                    allUserContestsDTO.Add(new ContestDTO(contest));
                }
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService, userManager.Object, signManager);
                var result = await sut.GetByUserAsync("current");

                Assert.AreEqual(result.Count(), allUserContestsDTO.Where(c => c.Status != "Finished").Count());
                Assert.AreEqual(string.Join(",", allUserContestsDTO.Where(c => c.Status != "Finished")), string.Join(",", result));
            }
        }

        [TestMethod]
        public async Task Return_UserContests_Past()
        {
            var options = Utils.GetOptions(nameof(Return_UserContests_Past));

            var categoryService = new Mock<ICategoryService>().Object;
            var userService = new Mock<IUserService>();
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null,
                null, null, null, null, null);
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>().Object;
            var signManager = new Mock<SignInManager<User>>(userManager.Object, contextAccessor.Object, userPrincipalFactory, null, null, null, null).Object;
            var context = new Mock<HttpContext>();
            contextAccessor.Setup(a => a.HttpContext).Returns(context.Object);

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Users.AddRangeAsync(Utils.SeedUsers());
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.Categories.AddRangeAsync(Utils.SeedCategories());
                await arrContext.Photos.AddRangeAsync(Utils.SeedPhotos());
                await arrContext.Contests.AddRangeAsync(Utils.SeedContests());
                await arrContext.UserContests.AddRangeAsync(Utils.SeedUserContests());
                await arrContext.Ranks.AddRangeAsync(Utils.SeedRanks());
                await arrContext.SaveChangesAsync();

                var user = arrContext.Users.Skip(4).First();
                userManager.Setup(u => u.GetUserName(signManager.Context.User)).Returns(user.UserName);
                userService.Setup(u => u.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult(user));
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var contestToEnroll = actContext.Contests.Last();
                var user = actContext.Users.Skip(4).First();
                var allUserContests = actContext.UserContests.Where(uc => uc.UserId == user.Id);
                var allUserContestsDTO = new List<ContestDTO>();
                foreach (var userContest in allUserContests)
                {
                    var contest = await actContext.Contests
                                      .Include(c => c.Category)
                                      .Include(c => c.Status)
                                      .FirstAsync(c => c.Id == userContest.ContestId && c.IsDeleted == false);
                    allUserContestsDTO.Add(new ContestDTO(contest));
                }
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService, userManager.Object, signManager);
                var result = await sut.GetByUserAsync("past");

                Assert.AreEqual(result.Count(), allUserContestsDTO.Where(c => c.Status == "Finished").Count());
                Assert.AreEqual(string.Join(",", allUserContestsDTO.Where(c => c.Status == "Finished")), string.Join(",", result));
            }
        }

        [TestMethod]
        public async Task ThrowsWhen_FilterNotValid()
        {
            var options = Utils.GetOptions(nameof(ThrowsWhen_FilterNotValid));

            var categoryService = new Mock<ICategoryService>().Object;
            var userService = new Mock<IUserService>();
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null,
                null, null, null, null, null);
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<User>>().Object;
            var signManager = new Mock<SignInManager<User>>(userManager.Object, contextAccessor.Object, userPrincipalFactory, null, null, null, null).Object;
            var context = new Mock<HttpContext>();
            contextAccessor.Setup(a => a.HttpContext).Returns(context.Object);

            using (var arrContext = new PhotoContestContext(options))
            {
                await arrContext.Users.AddRangeAsync(Utils.SeedUsers());
                await arrContext.Statuses.AddRangeAsync(Utils.SeedStatuses());
                await arrContext.Categories.AddRangeAsync(Utils.SeedCategories());
                await arrContext.Photos.AddRangeAsync(Utils.SeedPhotos());
                await arrContext.Contests.AddRangeAsync(Utils.SeedContests());
                await arrContext.UserContests.AddRangeAsync(Utils.SeedUserContests());
                await arrContext.Ranks.AddRangeAsync(Utils.SeedRanks());
                await arrContext.SaveChangesAsync();

                var user = arrContext.Users.Skip(4).First();
                userManager.Setup(u => u.GetUserName(signManager.Context.User)).Returns(user.UserName);
                userService.Setup(u => u.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult(user));
            }
            using (var actContext = new PhotoContestContext(options))
            {
                var contestToEnroll = actContext.Contests.Last();
                var user = actContext.Users.Skip(4).First();
                var allUserContests = actContext.UserContests.Where(uc => uc.UserId == user.Id);
                var allUserContestsDTO = new List<ContestDTO>();
                foreach (var userContest in allUserContests)
                {
                    var contest = await actContext.Contests
                                      .Include(c => c.Category)
                                      .Include(c => c.Status)
                                      .FirstAsync(c => c.Id == userContest.ContestId && c.IsDeleted == false);
                    allUserContestsDTO.Add(new ContestDTO(contest));
                }
                var sut = new ContestService(actContext, contextAccessor.Object, userService.Object, categoryService, userManager.Object, signManager);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetByUserAsync("wrong"));
            }
        }
    }
}
