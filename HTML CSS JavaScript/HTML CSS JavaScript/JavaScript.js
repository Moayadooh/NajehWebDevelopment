function Verify() {
    name = frm.name.value;
    mobileNo = frm.mobile.value;
    age = frm.age.value;
    gender = null;
    isOK = true;

    if (!isNaN(name)) {
        document.getElementById("name").style.border = "2px solid red";
        window.alert("Please enter a valid name!!");
        isOK = false;
    }
    if (!parseInt(mobileNo) || mobileNo.length != 8) {
        document.getElementById("mobile").style.border = "2px solid red";
        window.alert("Please enter a valid mobile number!!");
        isOK = false;
    }
    if (isNaN(age)) {
        document.getElementById("age").style.border = "2px solid red";
        window.alert("Please enter a valid age!!");
        isOK = false;
    }
    if (document.getElementById("male").checked)
        gender = frm.gender.value;
    else if (document.getElementById("female").checked)
        gender = frm.gender.value;
    if (gender == null) {
        window.alert("Please select a gender!!");
        isOK = false;
    }

    var progLangs = document.getElementsByName("language");
    var items = "";

    for (var i = 0; i < progLangs.length; i++) {
        if (progLangs[i].checked == true)
            items += progLangs[i].value + ", ";
    }

    if (isOK) {
        document.getElementById("name").style.border = "none";
        document.getElementById("mobile").style.border = "none";
        document.getElementById("age").style.border = "none";
        window.alert("Name is " + name + "\nMobile No is " + mobileNo + "\nAge is " + age + "\nGender is " + gender + "\nProgramming Languages is " + items);
    }
}

function ShowHide() {
    var status = document.getElementById("images").getElementsByTagName("img").style.display;
    if (status == "none")
        status = "block";
    else
        status = "none";
    document.getElementById("images").style.display = status;
}

function ChangeTitle() {
    document.getElementById("title1").innerHTML = "Oman";
}
