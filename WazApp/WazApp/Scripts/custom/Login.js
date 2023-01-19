$("#btnSubmitLogin").on("click", function () {
    submitDataLogin();
    //sibmitData();
});
function submitDataLogin() {
    var email = $("#email").val();
    var password = $("#password").val();

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


    //creating objects to send the data to the server.
    var obj = new Object();

    obj.Email = email;
    obj.Password = password;

    //ajax for posting data 
    $.ajax({
        type: "POST",
        url: "/Login/Login",
        data: JSON.stringify(obj),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response != null) {
                if (response.Status == "Success") {
                    if (response.User.Role == "ROL001") {
                        window.location.href = "/EmployeeProfile";
                    }
                    if (response.User.Role == "ROL002") {
                        window.location.href = "/EmployerProfile";
                    }
                } else {
                    alert(response.ResponseMessage);
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
