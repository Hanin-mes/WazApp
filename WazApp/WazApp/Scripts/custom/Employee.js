$("#btnSubmit").on("click", function () {
    RegisterEmployee();
});

$("#btnUpdateEmployee").on("click", function () {
    UpdateEmployee();
});

//I am giving here the variables in this function
function RegisterEmployee() {
    var firstName = $("#fname").val();
    var lastName = $("#lname").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var address = $("#address").val();
    var phoneNb = $("#phonenb").val();
    var dob = $("#dob").val();

    //if statements is mandatory to make sure to fill all the blocks
    if (firstName == "") {
        alert("First name is mandatory.");
        $("#fname").focus();
        return false;
    }
    if (lastName == "") {
        alert("Last name is mandatory.");
        $("#lname").focus();
        return false;
    }
    if (email == "") {
        alert("Email is mandatory.");
        $("#email").focus();
        return false;
    }
    if (password == "") {
        alert("Password is mandatory.");
        $("#password").focus();
        return false;
    }
    if (address == "") {
        alert("Address is mandatory.");
        $("#address").focus();
        return false;
    }
    if (phoneNb == "") {
        alert("Phone number is mandatory.");
        $("#phonenb").focus();
        return false;
    }
    if (dob == "") {
        alert("Check out the date of birth.");
        $("#dob").focus();
        return false;
    }
    //creating objects to send the data to the server.
    var obj = new Object();
    obj.FirstName = firstName;
    obj.LastName = lastName;
    obj.Email = email;
    obj.Password = password;
    obj.MobileNb = phoneNb;
    obj.Address = address;
    obj.dob = dob;

    //ajax for posting data 
    $.ajax({
        type: "POST",
        url: "/EmployeeRegister/AddEmployee",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                if (response.Status == "Error") {
                    alert(response.ResponseMessage);
                } else {
                    alert(response.ResponseMessage);
                    return false;
                }                
            }
            /*if (response != null) {
                alert("Name : " + response.Name + ", Designation : " + response.Designation + ", Location :" + response.Location);
            } else {
                alert("Something went wrong");
            }*/
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
function UpdateEmployee() {

    var EmployeeID = $("#EmployeeID").val();
    var UserID = $("#UserID").val();
    var Skills = $("#Skills").val();
    var ImagePath = $("#ImagePath").val();
    var CvPath = $("#CvPath").val();
    var DOB = $("#DOB").val();
    var Description = $("#Description").val();

    if (EmployeeID == "") {
        alert("Employee id is mandatory.");
        $("#EmployeeID ").focus();
        return false;
    }
    //check iza bkhalle l id aw bshila 
    if (UserID == "") {
        alert("User ID is mandatory.");
        $("#UserID").focus();
        return false;
    }
    if (Skills == "") {
        alert("Skills is mandatory.");
        $("#Skills").focus();
        return false;
    }
    if (ImagePath == "") {
        alert("Check image path.");
        $("#ImagePath").focus();
        return false;
    }
    if (CvPath == "") {
        alert("Cv Path is mandatory.");
        $("#CvPath").focus();
        return false;
    }
    if (DOB == "") {
        alert("Date of birth is mandatory.");
        $("#DOB").focus();
        return false;
    }
    if (Description == "") {
        alert("Description is mandatory.");
        $("#Description").focus();
        return false;
    }

    var obj = new Object();

    obj.EmployeeID = EmployeeID;
    obj.UserID = UserID;
    obj.Skills = Skills;
    obj.ImagePath = ImagePath;
    obj.CvPath = CvPath;
    obj.DOB = DOB;
    obj.Description = Description;

    //ajax for posting data 
    $.ajax({
        type: "POST",
        url: "/EmployeeProfile/UpdateEmployee",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                if (response.Status == "Success") {
                    alert(response.ResponseMessage);
                } else {
                    alert(response.ResponseMessage);
                    return false;
                }
            }
            /*if (response != null) {
                alert("Name : " + response.Name + ", Designation : " + response.Designation + ", Location :" + response.Location);
            } else {
                alert("Something went wrong");
            }*/
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });


}

