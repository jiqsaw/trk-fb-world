function BirthdayFormControl() {
    var ToId = $("#ToIds").val();
    if (ToId == null || ToId == "" || ToId == "0") {
        return false;
    }
    else { return true; }
}
$("#rgBirthdayFriends input[type='radio']").live("click", function () {
    var ToId = $(this).val();
    $("#ToIds").val(ToId);
    $("#birthdayResult").html('');
});

$("#btnBirthdaySubmit").live("click", function () {

    var ToId = $("#ToIds").val();
    var Message = $("#Message").val();

    if (ToId == null || ToId == "" || ToId == "0") {
        processResult(1, "Lütfen arkadaş seçiniz.", "#birthdayResult");
    }
    else if (parseInt(Message.length) < 2) {
        processResult(1, "Lütfen mesajınızı yazınız.", "#birthdayResult");
    }
    else {
        $("#BirthdayLoadingForm").show();
        $.ajax({
            url: "/World/BirthdaySmsSent",
            dataType: "json",
            data: { "ToId": ToId },
            success: function (response) {
                $("#BirthdayLoadingForm").hide();
                if (response.ToId != "0") {
                    processResult(3, "Arkadaşınıza mesajınız gönderilmiştir.", "#birthdayResult");
                    $("#birthdayResult").append("<ins class=\"space15\"></ins>");
                    var fbIndex = $("#rgBirthdayFriends>#fbFriend_" + ToId + ">input[type='radio']").index();

                    $("#rgBirthdayFriends>.fbFriend>input[type='radio']").eq(parseInt(fbIndex + 1)).attr("checked", "checked").next("label").attr("class", "rd-active");
                    $("#ToIds").val($("#rgBirthdayFriends>.fbFriend>input[type='radio']").eq(parseInt(fbIndex + 1)).val());

                    $("#fbFriend_" + ToId).hide();
                    var openedCount = 0;
                    $("#rgBirthdayFriends>.fbFriend").each(function () {
                        if ($(this).css("display") != "none") {
                            openedCount = parseInt(openedCount + 1);
                        }
                    });

                    if (openedCount == 0) {
                        $("#bdayForm").hide();
                        $("#upcomingBirthdayFriends").fadeIn('slow');
                        $("#birthdayTitle").html("DOĞUM GÜNÜ YAKLAŞAN ARKADAŞLARINIZ");
                    }
                }
                else {
                    processResult(1, "İşlem gerçekleşmedi.", "#birthdayResult");
                }
            }
        });

    }
});