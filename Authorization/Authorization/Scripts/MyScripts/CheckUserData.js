function CreateNewUser() {
    var login = document.getElementById("login").value;
    var password = document.getElementById("password").value;
    var Iemail = document.getElementById("Iemail");
    var Ipassword = document.getElementById("Ipassword");
    var flagEmail = false;
    var flagPassword = false;

    if (login.length < 4 || login.length > 21) {
        alert("email must be under 20 symbols and more than 5 symbols");
    }
    if (!CheckValidLogin(login)) {
        Iemail.style.display = "block";
    }
    else {
        flagEmail = true;
        Iemail.style.display = "none";
    }

    if (password.length < 4 || password.length > 11) {
        alert("password must be under 10 symbols and more than 4 symbols");
    }
    if (!CheckValidPassword(password)) {
        Ipassword.style.display = "block";
    }
    else {
        flagPassword = true;
        Ipassword.style.display = "none";
    }
    if (flagEmail === true && flagPassword === true) {
        var str = login + " " + password;
        $.post("/Home/CreateNewUser/", { param: str },
            function (data) {
                alert(data);
                
                location = "http://localhost:60849/Home/UserRoom";
            });
    }
}
function CheckValidLogin(login) {
    return (login.includes(".") && login.includes("@"));
}

function CheckValidPassword(password) {
    var upp = password.toLowerCase();
    if (password === upp) {
        return false;
    }
    return true;
}
