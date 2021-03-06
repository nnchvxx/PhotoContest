# PhotoContest
Web application that allows users to participate in photography contests and get their photos reviewed by the organizers.

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/Homepage.png)

## Team Members
* Angel Yankov - [GitHub](https://github.com/AngelYankov)
* Emil Nenchev - [GitHub](https://github.com/nnchvxx)

[**Click Here**](https://trello.com/b/ucbjOiuG/photocontest) for our Trello board

## Project Description
### Areas
* **Public part** -  accessible without authentication
* **Private part** - available for registered users only
* **Administrative part** - available for administrators only

#### Public Part
* The public part consists of a home page displaying winning photos from the latest finished contests and the newly organized contests you can join in separate sections on the page, as well as login and register page.

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/Carousels.png)

#### Private Part - Users

* After login, users see everything visible to website visitors and additionally they can:
    
     * See all contests available to enroll without invitation and filter them by phase

     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllOpen_UserView.png)
     
     * Enroll if a contest is in "phase 1"
     
     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/enroll.png)

     * Upload a photo in a contest if they are already enrolled

     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AddPhoto.png)

     * View all photos of a contest if it is finished and they have participated

     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/ContestPhotos_UserView.png)

     * View all reviews for all photos if the contest has finished
     
     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/PhotoReviews_UserView.png)

     * View all contests they participate in and filter them by current or past, again they can either see an "Enroll", "Add Photo" or "View Photos" option
     
     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/MyContests.png)

     * View all photos they have uploaded
     
     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/MyPhotos.png)

     * View their account information along with their current rank and the amount of points left until the next one
     
     ![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/MyAccount.png)
     
#### Private Part - Organizers
* Organizer see everything visible to users and additionally they can:
     * Create contests ??? CRUD operations for contests
     * Rate photos ??? CRUD operations for reviews
     * Manage users ??? CRUD operations for users
     * Manage photos - CRUD operations for photos
     * Manage categories - CRUD operations for categories
     
* See all registered users and filter them by username

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllUsers_OrganizerView.png)

* See all contest participants sorted by rank

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllParticipants_OrganizerView.png)

* See all created contests, filter them by phase and sort them by name/category/newest/oldest and order them

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllContests_OrganizerView.png)

* Create contest

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/CreateContest.png)

* Choose jury for a contest if it is in "phase 1" or "phase 2"

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/ChooseJury.png)

* Invite user to a contest if it is "invitational"

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/Invite.png)

* View photos of a contest and rate them if the contest is in "phase 2" or see all reviews for a photo if the contest is over

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/ContestPhotos_OrganizerView.png)

* View details of a contest

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/ContestDetails_OrganizerView.png)

* Edit a contest

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/UpdateContest.png)

* Delete a contest

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/DeleteContest.png)

* View all photos on the website and edit them

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllPhotos_OrganizerView.png)

* Rate photo

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/RatePhoto.png)

* View all contest categories and create a new one

![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/AllCategories.png)

#### Administrative Part
* Admin as all the funcionality of the organizer and can:
     * Create user that is in organizer role

## Technologies
* ASP.NET Core
* ASP.NET Identity
* Entity Framework Core
* MS SQL Server
* HTML
* CSS
* Bootstrap

## Notes
* In-memory database, MSTest and Moq for testing
* Data transfer objects(DTOs)
* Used branches during development of features
* Above 80% Unit test code coverage of the business logic

## Database Diagram
![Alt text](https://gitlab.com/AngelYankov/photocontest/-/raw/master/Images/DatabaseDiagram.png)
