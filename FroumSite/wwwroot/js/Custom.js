///<reference path="../lib/jquery/dist/jquery.js" />

function hideLoader() {
    $("#loaderbody").addClass('hide');
}

function showLoader() {
    $("#loaderbody").removeClass('hide');
}

$(function () {
    $("#view-all-posts").fadeIn(1000);

    $("#loaderbody").addClass('hide');

    $(document).on({
        'ajaxStart': showLoader,
        'ajaxSuccess': hideLoader,
        'ajaxError': hideLoader
    })

    $(".btn").on({
        mouseleave: function () {
            $(this).css("box-shadow", "0px 0px black");
        },
        mouseenter: function () {
            $(this).css("box-shadow", "5px 5px black");
        },
        mousedown: function () {
            $(this).css("box-shadow", "3px 3px black");
        },
        mouseup: function () {
            $(this).css("box-shadow", "5px 5px black");
        }
    });
});


ajaxLikeTopic = () => {
    $.ajax({
        type: "POST",
        url: '/Topics/LikeTopic',
        success: function (res) {
            if (res.isValid) {
                $("#LikeButton").html(res.html);
            }
        },
        error: function () {

        }
    })
}

ajaxDeletePost = (Id) => {
    $.ajax({
        type: "POST",
        url: '/Topics/DeletePostByUser' + Id,
        success: function (res) {
            if (res.isValid) {
                $("#LikeButton").html(res.html);
            }
        }
    })
}

ajaxLikePost = (id) => {
    $.ajax({
        type: "POST",
        url: '/Topics/LikePost/' + id,
        success: function (res) {
            if (res.isValid) {
                $("#LikePostButtonDiv").html(res.html);
            }
        },
        error: function () {
            alert('error like!!!')
        }
    })
}

showPopupModal = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

showCenteredModal = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#centered-modal .modal-body").html(res);
            $("#centered-modal .modal-title").html(title);
            $("#centered-modal").modal('show');
        }
    })
}

ModifyPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all-posts").html(res.html);
                    $("#centered-modal .modal-body").html('');
                    $("#centered-modal .modal-title").html('');
                    $("#centered-modal").modal('hide');

                }
                else {
                    $("#centered-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
            }
        })

    } catch (e) {
        alert(e);
    }

    //to prevent default form submit event
    return false;
}

ModifyTopic = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all-topics").html(res.html);
                    $("#centered-modal .modal-body").html('');
                    $("#centered-modal .modal-title").html('');
                    $("#centered-modal").modal('hide');

                }
                else {
                    $("#centered-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                alert(err)
            }
        })

    } catch (e) {
        alert(e);
    }

    //to prevent default form submit event
    return false;
}


ajaxSavePost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {

                    $('#txtPost').val('');
                    $("#view-all-posts").html(res.html);
                    $("#centered-modal .modal-body").html('');
                    $("#centered-modal .modal-title").html('');
                    $("#centered-modal").modal('hide');
                    //$("#view-all-posts:last-child").animate(
                    //    {
                    //        'border-color': red
                    //    }, 200, function () {
                    //        $(this).animate({
                    //            'border-color': '#dee2e6'
                    //        }, 200)
                    //    });
                }
                else {
                    $("#centered-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
            }
        })

    } catch (e) {
        alert(e);
    }

    //to prevent default form submit event
    return false;
}

jQueryAjaxPost = form => {
    try {
        $.ajax({

            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {

                    $("#view-all-topics").html(res.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');
                }
                else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                alert(err)
            }
        })

    } catch (e) {
        alert(e);
    }

    //to prevent default form submit event
    return false;
}