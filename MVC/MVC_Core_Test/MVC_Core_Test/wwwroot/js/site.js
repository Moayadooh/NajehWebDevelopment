
function createSelection(field, start, end) {
    if (field.createTextRange) {
        var selRange = field.createTextRange();
        selRange.collapse(true);
        selRange.moveStart('character', start);
        selRange.moveEnd('character', end);
        selRange.select();
        field.focus();
    } else if (field.setSelectionRange) {
        field.focus();
        field.setSelectionRange(start, end);
    } else if (typeof field.selectionStart != 'undefined') {
        field.selectionStart = start;
        field.selectionEnd = end;
        field.focus();
    }
}

function Select(start, end) {
    var message = $('.datepickerFrom')[0];
    createSelection(message, start, end);
    message.value.substring(message.selectionStart, message.selectionEnd);
}

function getSelectionText() {
    var text = "";
    if (window.getSelection) {
        text = window.getSelection().toString();
    } else if (document.selection && document.selection.type != "Control") {
        text = document.selection.createRange().text;
    }
    return text;
}

function CheckDate() {
    var date = $('.datepickerFrom').val().split("/");
    function CheckPartOfDate(currentDate, format, len) {
        var newDate = "";
        for (var i = 0; i < currentDate.length; i++) {
            if (!isNaN(currentDate[i]))
                newDate += currentDate[i];
            if (isNaN(currentDate)) {
                newDate = format;
            }
            if (i == len)
                break;
        }
        if ($('.datepickerFrom').val().length == 10) {
            if (!isNaN(newDate) && newDate.length > 1 && isNaN(date[1]) && date[1].length > 1) {
                Select(3, 5);
            }
            else if (!isNaN(date[1]) && date[1].length > 1 && isNaN(date[2]) && date[2].length > 3) {
                Select(6, 10);
            }
            else if (isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
                Select(0, 2);
            }
            else if (!isNaN(date[0]) && !isNaN(date[1]) && !isNaN(date[2])) {
                Select(0, 2);
            }
        }
        return newDate;
    }

    //Day
    var currentDay = "", newDay = "";
    if (typeof date[0] === 'undefined' || date[0] == '')
        currentDay = "dd";
    else
        currentDay = date[0];
    newDay = CheckPartOfDate(currentDay, "dd", 1);

    //Month
    var currentMonth = "", newMonth = "";
    if (typeof date[1] === 'undefined' || date[1] == '')
        currentMonth = "mm";
    else
        currentMonth = date[1];
    newMonth = CheckPartOfDate(currentMonth, "mm", 1);

    //Year
    var currentYear = "", newYear = "";
    if (typeof date[2] === 'undefined' || date[2] == '')
        currentYear = "yyyy";
    else
        currentYear = date[2];
    newYear = CheckPartOfDate(currentYear, "yyyy", 3);

    $('.datepickerFrom').val(newDay + "/" + newMonth + "/" + newYear);
}

function SelectPartOfDate() {
    var date = $('.datepickerFrom').val().split("/");
    if (isNaN(date[0])) {
        Select(0, date[0].length);
    }
    else if (isNaN(date[1])) {
        Select(date[0].length + 1, date[0].length + date[1].length + 1);
    }
    else if (isNaN(date[2])) {
        Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
    }
    else {
        Select(0, date[0].length);
    }
}

function SetMaxAndMinDayAndMonth() {
    var date = $('.datepickerFrom').val().split("/");

    //Set max month to 12 & min month to 1
    if (!isNaN(date[1]) && date[1] > 12)
        date[1] = 12;
    else if (!isNaN(date[1]) && date[1] < 1)
        date[1] = 1;

    //Set max day to 31 & min day to 1
    if (!isNaN(date[0]) && !isNaN(date[1]) && (date[1] == 1 || date[1] == 3 || date[1] == 5 || date[1] == 7 || date[1] == 8 || date[1] == 10 || date[1] == 12)) {
        if (!isNaN(date[0]) && date[0] > 31)
            date[0] = 31;
        else if (!isNaN(date[0]) && date[0] < 1)
            date[0] = 1;
    }

    //Add 0 before single digit
    if (!isNaN(date[0]) && date[0].length == 1)
        date[0] = '0' + date[0];

    if (!isNaN(date[1]) && date[1].length == 1)
        date[1] = '0' + date[1];

    if (!isNaN(date[2]) && date[2].length == 1)
        date[2] = '000' + date[2];
    else if (!isNaN(date[2]) && date[2].length == 2)
        date[2] = '00' + date[2];
    else if (!isNaN(date[2]) && date[2].length == 3)
        date[2] = '0' + date[2];

    $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
}

$(function () {
    $('.datepickerFrom').datepicker({
        uiLibrary: 'bootstrap4',
        iconsLibrary: 'fontawesome',
        format: 'dd/mm/yyyy',
        showOnFocus: false,
        keyboardNavigation: false,
        //value: 'dd/mm/yyyy',
        width: 234,
        size: 'small'
    });

    //Input number only
    $(".datepickerFrom").bind({
        keydown: function (e) {
            if (e.shiftKey === true) {
                if (e.which == 9) {
                    return true;
                }
                return false;
            }
            if (e.which == 13) {
                return true;
            }
            if (e.which >= 96 && e.which <= 105) {
                return true;
            }
            if (e.which > 57) {
                return false;
            }
            return true;
        }
    });

    //Prevent delete '/' character
    $('.datepickerFrom')[0].addEventListener("keydown", function (e) {
        var start = this.selectionStart,
            end = this.selectionEnd,
            value = this.value,
            key = e.keyCode;

        if (key == 8 && value[start - 1] == '/') e.preventDefault();
        if (key == 46 && value[start] == '/') e.preventDefault();
        if ((key == 8 || key == 46) && value.substring(start, end).indexOf('/') != -1) e.preventDefault();

    }, false);

    //Move in date parts
    $(document).keydown(function (e) {
        var date = $('.datepickerFrom').val().split("/");
        if (e.keyCode == '37') {
            e.preventDefault();
            if ($('.datepickerFrom').val().length < 10) {
                SetMaxAndMinDayAndMonth();
                SelectPartOfDate();
            }
            else if (getSelectionText() == date[1])
                Select(0, date[0].length);
            else if (getSelectionText() == date[2])
                Select(date[0].length + 1, date[0].length + date[1].length + 1);
            else {
                //e.preventDefault();
                //$('.datepickerFrom').blur();
                //SetMaxAndMinDayAndMonth();
                //$(".datepickerFrom").trigger("click");
                //$(".datepickerFrom").trigger("focus");
                //Select(0, date[0].length);
                //Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
            }
        }
        else if (e.keyCode == '39') {
            e.preventDefault();
            if ($('.datepickerFrom').val().length < 10) {
                SetMaxAndMinDayAndMonth();
                SelectPartOfDate();
            }
            else if (getSelectionText() == date[0] && date[0] != date[1])
                Select(date[0].length + 1, date[0].length + date[1].length + 1);
            else if (getSelectionText() == date[1])
                Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
            else {
                //e.preventDefault();
                //$('.datepickerFrom').blur();
                //SetMaxAndMinDayAndMonth();
                //$(".datepickerFrom").trigger("click");
                //$(".datepickerFrom").trigger("focus");
                //Select(0, date[0].length);
                //Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
            }
        }
    });

    //Press Backspace key
    $(document).keyup(function (e) {
        if (e.keyCode == 8) {
            if ($('.datepickerFrom').val().length == 10) {
                var date = $('.datepickerFrom').val().split("/");
                if (date[0] == 'dd' || date[1] == 'mm' || date[2] == 'yyyy') {
                    if (date[1] != 'mm') {
                        date[1] = 'mm';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select(date[0].length + 1, date[0].length + date[1].length + 1);
                    }
                    else if (date[0] != 'dd') {
                        date[0] = 'dd';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select(0, date[0].length);
                    }
                    else if (date[2] != 'yyyy') {
                        date[2] = 'yyyy';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
                    }
                }
                else {
                    if (date[2] == getSelectionText()) {
                        date[2] = 'yyyy';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
                    }
                    else if (date[1] == getSelectionText()) {
                        date[1] = 'mm';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select(date[0].length + 1, date[0].length + date[1].length + 1);
                    }
                    else if (date[0] == getSelectionText()) {
                        date[0] = 'dd';
                        $('.datepickerFrom').val(date[0] + "/" + date[1] + "/" + date[2]);
                        Select(0, date[0].length);
                    }
                }
            }
        }
    });

    $('.datepickerFrom').click(function () {
        SelectPartOfDate();
    });

    $('.datepickerFrom').on("input", function () {
        CheckDate();
    });

    $(".datepickerFrom").on('select', function () {

        //Prevent delete selected day value
        window.onkeydown = function (event) {
            if (event.which == 8) {
                event.preventDefault();

                var date = $('.datepickerFrom').val().split("/");
                var partToSelect = 0;
                if (date[0].length < 2)
                    partToSelect = 1;
                else if (date[1].length < 2)
                    partToSelect = 2;
                else if (date[2].length < 4)
                    partToSelect = 3;

                SetMaxAndMinDayAndMonth();

                if (partToSelect == 1)
                    Select(0, date[0].length);
                else if (partToSelect == 2)
                    Select(date[0].length + 1, date[0].length + date[1].length + 1);
                else if (partToSelect == 3)
                    Select($('.datepickerFrom').val().length - 4, $('.datepickerFrom').val().length);
            }
        };
    });

    $('.datepickerFrom').on("focus", function () {
        CheckDate();
        SelectPartOfDate();

        //Disable Up and Down Arrows keys
        var ar = new Array(38, 40);
        var disableArrowKeys = function (e) {
            if ($.inArray(e.keyCode, ar) >= 0) {
                e.preventDefault();
            }
        }
        $(document).keydown(disableArrowKeys);

        //Press Enter key
        $(document).on('keypress', function (e) {
            if (e.which == 13) {
                $('.datepickerFrom').blur();
                SetMaxAndMinDayAndMonth();
            }
        });
    });

    $('.datepickerFrom').on('blur', function () {
        SetMaxAndMinDayAndMonth();
    });

    jQuery(".datepickerFrom").on("invalid", function (event) {
        event.target.setCustomValidity('Please enter valid date.');
    });
});