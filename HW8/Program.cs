using HW8.Database;
using HW8.Entities;
using HW8.Services;
SeedData.Seed();
Userservices userservices = new Userservices();
CourseService courseService = new CourseService();
Pre_Menu();
void Pre_Menu()
{
    int option1 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("**************************");
        Console.WriteLine("Welcome to sipad.");
        Console.WriteLine("1.Log in.");
        Console.WriteLine("2.Sign up.");
        Console.WriteLine("3.Exit.");
        Console.WriteLine("**************************");
        option1 = int.Parse(Console.ReadLine());
        switch (option1)
        {
            case 1:
                Login();
                break;
            case 2:
                Register();
                break;
        }
    }
    while (option1 < 3);
}
 void Login()
{
    Console.Clear();
    Console.WriteLine("**************************");
    Console.WriteLine("Select your role (Enter number): ");
    Console.Write("1.Operator   2.University Professor  3.Student 4.Logout");
    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid Expression,try again.");
        Console.WriteLine("Press any botton.");
        Console.ReadKey();
    }
    Console.Write("Please Enter your Email: ");
    var email = Console.ReadLine();
    Console.Write("Please Enter your password: ");
    var passsword = Console.ReadLine();
    var result = userservices.Login(email, passsword,out User? user);
    if(!result.IsDone)
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("Press any botton.");
        Console.ReadKey();
    }
    switch (option)
    {
        case 1:
            OperatorMenu(user);
            break;
        case 2:
            TeacherMenu(user);
            break;
        case 3:
            StudentMenu(user);
            break;
        case 4:
            break;
    }
} //Done
 void Register()
{
    Console.Clear();
    Console.WriteLine("**************************");
    Console.WriteLine("Select your role (Enter number): ");
    Console.WriteLine("1.Operator   2.University Professor  3.Student");
    if (!int.TryParse(Console.ReadLine(), out int role))
    {
        Console.WriteLine("Invalid Expression,try again.");
        Console.WriteLine("Press any botton.");
        Console.ReadKey();
    }
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    Console.Write("Please enter your lastname: ");
    string lastname = Console.ReadLine();
    Console.Write("Pls Enter The Email: ");
    string? mail = Console.ReadLine();
    Console.Write("Pls Enter The Password: ");
    string? Pass = Console.ReadLine();
    User user = null;
    switch (role)
    {
        case 1:
            user = new Operator(name,lastname,mail);
            break;
        case 2:
            user = new Teacher(name, lastname, mail);
            userservices.SetTeachId((Teacher)user); 
            break;
        case 3:
            user = new Student(name, lastname, mail);
            userservices.SetStuId((Student)user);
            break;
    }
    var result = userservices.Register(user,Pass);
    if (!result.IsDone)
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("Press any botton.");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine(result.Message);
        Console.WriteLine("Press any botton.");
        Console.ReadKey();
    }
}
void StudentMenu(User? student)
    {
        if (Storage.Onlineuser == null || Storage.Onlineuser is not Student || Storage.Onlineuser != student)
        {
            Console.WriteLine("You cannot access the student menu.Please login first.");
            Console.WriteLine("Press any botton to continue.");
            Console.ReadKey();
        }
        else
        {
        Student currentUser = (Student)userservices.GetCurrentUser();
        bool check = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1.List of courses.");
                Console.WriteLine("2.Unit selection.");
                Console.WriteLine("3.Semester schedule");
                Console.WriteLine("4.Log out");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid Expression,try again.");
                    Console.WriteLine("Press any botton.");
                    Console.ReadKey();
                }
                switch (option)
                {
                    case 1:
                      Console.Clear();
                      Console.WriteLine("**********Courses**********");
                      courseService.ListOfcourses();
                      Console.WriteLine("***************************");
                      Console.Write("Press Any Key To Continiue:");
                      Console.ReadLine();
                    break;
                    case 2:
                      Console.Clear();                     
                      UnitSelectionMenu(currentUser);
                    break;
                    case 3:
                        Console.Clear();
                        userservices.ListofStudentCourse(currentUser);
                        Console.ReadKey();
                        break;
                    case 4:
                        Storage.Onlineuser = null;
                        check = false;
                        break;
                }
        } 
        while (check == true);
        }
    }
void OperatorMenu(User? @operator)
{
    if (Storage.Onlineuser == null || Storage.Onlineuser is not Operator || Storage.Onlineuser != @operator)
    {
        Console.WriteLine("You cannot access the Operator menu.Please login first.");
        Console.WriteLine("Press any botton to continue.");
        Console.ReadKey();
    }
    else
    {
        bool check = true;
        do
        {
            Console.Clear();
            Console.WriteLine($"******Operator {Storage.Onlineuser.Name}******");
            Console.WriteLine("1.Management of Users.");
            Console.WriteLine("2.Change course capacity.");
            Console.WriteLine("3.Activate users");
            Console.WriteLine("4.Add new course.");
            Console.WriteLine("5.Log out");
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid Expression,try again.");
                Console.WriteLine("Press any botton.");
                Console.ReadKey();
            }
            switch (option)
            {
                case 1:
                    bool check1 = true; 
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1.List of users.");
                        Console.WriteLine("2.Remove user.");
                        Console.WriteLine("3.Exit.");
                        if (!int.TryParse(Console.ReadLine(), out int option1))
                        {
                            Console.WriteLine("Invalid Expression,try again.");
                            Console.WriteLine("Press any botton.");
                            Console.ReadKey();
                        }
                        switch(option1)
                        {
                            case 1:
                                Console.WriteLine("*******Users*******");
                                userservices.ListOfUsers();
                                Console.WriteLine("*******************");
                                Console.WriteLine("Press any botton.");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.WriteLine("*******Users*******");
                                userservices.ListOfUsers();
                                Console.WriteLine("*******************");
                                Console.WriteLine("Enter user id: ");
                                var uid=Int32.Parse(Console.ReadLine());
                                userservices.RemoveUser(uid);
                                Console.WriteLine("User removed");
                                Console.WriteLine("Press any botton.");
                                Console.ReadKey();
                                break;
                            case 3:
                                check = false;
                                break;
                        }
                    } 
                    while (check==true);
                    break;
                case 2:
                    Console.WriteLine("**********Courses**********");
                    courseService.ListOfcourses();
                    Console.WriteLine("***************************");
                    Console.WriteLine("Enter course id : ");
                    var cid = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new capacity: ");
                    var cap= Int32.Parse(Console.ReadLine());
                    var re = courseService.ChangeCoursecap(cid, cap);
                    Console.WriteLine(re.Message);
                    Console.WriteLine("Press any botton.");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("----------InActive Users----------");
                    userservices.ListOfInActiveUsers();
                    var res4 = userservices.ListOfInActiveUsers();
                    Console.WriteLine(res4.Message);
                    Console.WriteLine("==================================");
                    Console.WriteLine("Enter user id: ");
                    var usid = Int32.Parse(Console.ReadLine());
                    string  m = userservices.Activateuser(usid);
                    Console.WriteLine(m);
                    Console.WriteLine("Press any botton.");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Please Enter Course Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Please Enter the Capacity of course: ");
                    var Cap = int.Parse(Console.ReadLine());
                    Console.Write("Please Enter Course unit: ");
                    int un = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Course day: ");
                    Console.WriteLine("1.Saturday");
                    Console.WriteLine("2.Sunday");
                    Console.WriteLine("3.Monday");
                    Console.WriteLine("4.Tuesday");
                    Console.WriteLine("5.Wednesday");
                    var day = Int32.Parse(Console.ReadLine());
                    DayOfWeek dayOfWeek = DayOfWeek.Monday;
                    switch(day)
                    {
                        case 1:
                            dayOfWeek = DayOfWeek.Saturday;
                            break;
                        case 2:
                            dayOfWeek = DayOfWeek.Sunday;
                            break;
                        case 3:
                            dayOfWeek = DayOfWeek.Monday;
                            break;
                        case 4:
                            dayOfWeek = DayOfWeek.Tuesday;
                            break;
                        case 5:
                            dayOfWeek = DayOfWeek.Wednesday;
                                break;
                    }
                    Console.Write("Please Enter Start time: ");
                    TimeOnly sTime = TimeOnly.Parse(Console.ReadLine());
                    Console.Write("Please Enter End time: ");
                    TimeOnly eTime = TimeOnly.Parse(Console.ReadLine());
                    UniversityCourse newcourse = new UniversityCourse(title, Cap, un,dayOfWeek,sTime,eTime);
                    Console.WriteLine("*****Teachers*****");
                    var res = userservices.ListOfTeachers();
                    if(!res.IsDone)
                    {
                        Console.WriteLine(res.Message);
                    }
                    Console.WriteLine("******************");
                    Console.WriteLine("Please Select Course Teacher by id: ");
                    var id = Int32.Parse(Console.ReadLine());
                    courseService.AddCourse(newcourse,userservices.GetTeacher(id));
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                    break;
                case 5:
                    Storage.Onlineuser = null;
                    check = false;
                    break;
            }
        }
        while (check == true);
    }
}
void TeacherMenu(User? teacher)
{
    if (Storage.Onlineuser == null || Storage.Onlineuser is not Teacher || Storage.Onlineuser != teacher)
    {
        Console.WriteLine("You cannot access the Teacher menu.Please login first.");
        Console.WriteLine("Press any botton to continue.");
        Console.ReadKey();
    }
    else
    {
        Teacher currentUser = (Teacher)userservices.GetCurrentUser();
        bool check = true;
        do
        {
            Console.Clear();
            Console.WriteLine($"******Teacher {Storage.Onlineuser.Name}******");
            Console.WriteLine("1.List of Students.");
            Console.WriteLine("2.Set your Course.");
            Console.WriteLine("3.Change Student status.");
            Console.WriteLine("4.Log out");
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid Expression,try again.");
                Console.WriteLine("Press any botton.");
                Console.ReadKey();
            }
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("**********Students**********");
                    userservices.ListOfStudentds(currentUser);
                    Console.WriteLine("Press any botton.");
                    Console.ReadKey();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Storage.Onlineuser = null;
                    check = false;
                    break;
            }
        }
        while (check == true);
    }
}
void UnitSelectionMenu(Student student)
{
    bool c =true;
    do
    {
        Console.Clear();
        Console.WriteLine("****************** Selected Courses *******************");
        foreach (var course in student.Courses)
        {
            Console.WriteLine(course);
        }
        Console.WriteLine("****************** Selected Courses *******************");

        Console.WriteLine("****************** Accessible Courses *******************");
        courseService.ListOfcourses();
        Console.WriteLine("****************** Accessible Courses *******************");
        Console.Write("Please Select Your Course Id : ");
        var selectedCourseId = Int32.Parse(Console.ReadLine());
        var res = userservices.EntekhabVahed(selectedCourseId, student);
        Console.WriteLine(res.Message);
        Console.WriteLine("1.Exit.");
        Console.WriteLine("2.Continue.");
        var cho = Int32.Parse(Console.ReadLine());
        switch(cho)
        {
            case 1:
                c = false;
                break;
        }
    }while(c==true);
    
}
