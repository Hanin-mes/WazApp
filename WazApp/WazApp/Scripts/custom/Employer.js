$("#btnSubmitEmployer").on("click", function () {
    RegisterEmployer();
});

$("#btnUpdateEmployer").on("click", function () {
    UpdateEmployer();
    //this button is for save the updated data in page 
});

//I am giving here the variables in this function
function RegisterEmployer() {
    var firstName = $("#fname").val();
    var lastName = $("#lname").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var address = $("#address").val();
    var phoneNb = $("#phonenb").val();
    var city = $("#city").val();

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
    if (city == "") {
        alert("Check out the city.");
        $("#city").focus();
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
    obj.city = city;

    //ajax for posting data 
    $.ajax({
        type: "POST",
        url: "/EmployerRegister/AddEmployer",
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
function UpdateEmployer() {

        var EmployerID = $("#EmployerID").val();
        var UserID = $("#UserID").val();
        var Position = $("#Position").val();
        var Website = $("#Website").val();
        var CompanyName = $("#CompanyName").val();
        var CompanyAddress = $("#CompanyAddress").val();
        var Country = $("#Country").val();
        var City = $("#City").val();

    if (EmployerID == "") {
        alert("Check Employer ID.");
        $("#EmployerID ").focus();
        return false;
    }


    if (Position == "") {
        alert("Position is mandatory.");
        $("#Position ").focus();
        return false;
    }
    if (Website == "") {
        alert("Website is mandatory.");
        $("#Website").focus();
        return false;
    }
    if (CompanyName == "") {
        alert("Company Name is mandatory.");
        $("#CompanyName").focus();
        return false;
    }
    if (CompanyAddress == "") {
        alert("Company Address is mandatory.");
        $("#CompanyAddress").focus();
        return false;
    }
    if (Country == "") {
        alert("Country is mandatory.");
        $("#Country").focus();
        return false;
    }
    if (City == "") {
        alert("City is mandatory.");
        $("#City").focus();
        return false;
    }

    var obj = new Object();
    obj.EmployerID = EmployerID;
    obj.UserID = UserID;
    obj.Position = Position;
    obj.Website = Website;
    obj.CompanyName = CompanyName;
    obj.CompanyAddress = CompanyAddress;
    obj.Country = Country;
    obj.City = City;

    //ajax for posting data 
    $.ajax({
        type: "POST",
        url: "/EmployerProfile/UpdateEmployer",
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
