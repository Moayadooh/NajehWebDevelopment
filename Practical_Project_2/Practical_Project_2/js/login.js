
var jsonObj = [];
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
    jsonObj.push({
        "Name": profile.getName(),
        "Email": profile.getEmail()
    });
    sendProfileData();
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

function sendProfileData() {
    $(function () {
        $.ajax({
            type: "POST",
            url: "/Home/LoginWithGoogle",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(jsonObj),
            success: function (response) {
                window.location.href = response.Url;
            },
            error: function (data) {
                alert(data.responseText);
            }
        });
    });
}