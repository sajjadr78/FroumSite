$(function () {
    $("#btnShowSubjectDetails").on("click", function () {
        var subjectId = $(this).attr("data");
        
       var a=  $.ajax({
            url: "/Home/SubjectDetails/",
            type: "get",
            data: { id: subjectId }
        }).done(function (res) {
            $("#Details").html(res)
        })

        //$(".container").load("/Home/SubjectDetails/" + subjectId);
    })

    $("#btnRoomDetails").on("click", function () {
        var roomId = $(this).attr("data");

        $.ajax({
            url: "/Home/RoomDetails/",
            type: "get",
            data: { id: roomId }
        }).done(function (res) {
            $("#Details").html(res)
        })
    })
})