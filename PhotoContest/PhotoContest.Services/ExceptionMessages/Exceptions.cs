namespace PhotoContest.Services.ExceptionMessages
{
    public static class Exceptions
    {
        public const string InvalidCategory = "There is no such category.";
        public const string InvalidStatus = "There is no such status.";
        public const string InvalidContestName = "There is no contest with such name.";
        public const string InvalidContestID = "There is no contest with such ID.";
        public const string InvalidPhotoID = "There is no photo with such ID.";
        public const string InvalidUserID = "There is no user with such ID.";
        public const string InvalidUser = "There is no such user.";
        public const string InvalidFilter = "Filter is not valid.";
        public const string InvalidPhase = "Phase is not valid.";
        public const string InvalidSorting = "Sorting is not valid.";
        public const string InvalidDateTimePhase1 = "Date for 'Phase 1' should be in the future.";
        public const string InvalidDateTimePhase2 = "Date for 'Phase 2' should be between 1 and 31 days after 'Phase 1' and before date for 'Finished'.";
        public const string InvalidDateTimeFinished = "Date for 'Finished' phase should be at least 1 hour after 'Phase 2' and not more than 1 day after 'Phase 2'.";
        public const string InvalidPointsValue = "Invalid points value.";
        public const string InvalidJuryUser = "User cannot be chosen as jury.";
        public const string InvalidJury = "User is participating in this contest.";
        public const string InvalidParticipant = "User cannot be chosen as a contest participant.";
        public const string InvalidContestPhase = "Contest is not in evaluation phase.";
        public const string InvalidComment = "The comment is not valid.";
        public const string InvalidReviewId = "There is no review with such ID.";
        public const string DeletedCategory = "Category is deleted.";
        public const string RequiredContestName = "Contest name is required.";
        public const string RequiredPhotoName = "Photo name is required.";
        public const string RequiredPhotoDescription = "Photo description is required.";
        public const string RequiredPhotoURL = "Photo URL is required.";
        public const string RequiredUserID = "User ID is required.";
        public const string RequiredContestID = "Contest ID is required.";
        public const string RequiredRankID = "Rank ID is required.";
        public const string RequiredFirstName = "First name is required.";
        public const string RequiredLastName = "Last name is required.";
        public const string RequiredEmail = "Email is required.";
        public const string EnrolledUser = "User already enrolled in this contest.";
        public const string IncorrectPassword = "Password must contain letters and numbers.";
        public const string IncorrectCredentials = "Incorrect credentials for user.";
        public const string ExistingEmail = "Email already exists.";
        public const string ExistingJury = "User is jury in this contest.";
        public const string NotFoundEmail = "Email not found.";
        public const string NotFoundRole = "Role not found.";
        public const string NotAllowedEnrollment = "Only invited users can enroll in this contest.";
        public const string NotAllowedInvitation = "Contest is not invitational.";
        public const string ReviewedPhoto = "Photo is already reviewed.";
        public const string ClosedContest = "Contest is not open yet.";
        public const string NoParticipants = "There are no participants yet.";
        public const string SuccesfullyAddedRole = "Role added succesfully.";
        public const string WrongCategoryComment = "Photo is in a wrong category.";
        public const string UserNotJury = "User is not in the jury for this contest.";
        public const string InvalidUserAccessToPhotos = "User does not have access to the contest's photos.";
        public const string RestoreUserAccount = "Registration is not completed, but your account has been recovered. You can login to your account.";
        public const string InvalidUserInfo = "Value for user {0} should be between {2} and {1} characters.";
        public const string InvalidPhotoInfo = "Value for photo {0} should be between {2} and {1} characters.";
        public const string InvalidContestInfo = "Value for contest {0} should be between {2} and {1} characters.";
        public const string InvalidReviewInfo = "Value for review {0} should be between {2} and {1} characters.";
        public const string NotMatchingEmail = "The email does not match.";
        public const string InvalidPassword = "Value for {0} must be between {2} and {1} characters long.";
        public const string NotMatchingPassword = "The password and confirm password fields must match.";
        public const string NotEnrolledInContest = "You have not enrolled in this contest.";
        public const string AlreadyUploadedAPhoto = "You have already uploaded a photo.";
    }
}
