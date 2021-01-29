//send notifications
var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();
connection.on("NewOrder", function (number,date) {
    var x = `<div class="alert alert-dismissible fixed-bottom radius text-white border-0" id="successSave"
                style="width: fit-content; left: auto; right: 20px; bottom: auto; top: 20px; background: linear-gradient(180deg,#F97F4690 0,#f7497290);">
                <div class="card-header border-white d-flex justify-content-between align-items-center"
                style="border-top-left-radius: 14px !important; border-top-right-radius: 14px !important">
                <span class="text-white">${date}</span>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
                </div>
                <div class="card-body">
                <p class="text-white">Has New Oeder # ${number}</p>
                </div>
            </div>`;
    $(".alertnote").append(x);
    var x = $('.notfy li').length;
    $("#ordersNumber").empty();
    $("#ordersNumber").html(x);
    var li = `<li class='m-2'>
                                <span>OrderDate:${date}</span><br>
                                <span>OrderId#${number}</span><br>
                                <hr />
                            </li>`;
    
    $(".notfy").append(li);
    var aud = new Audio("/got-it-done-613.mp3")
    aud.play();
});
connection.on("cancel", function (number, date) {
    var x = `<div class="alert alert-dismissible fixed-bottom radius text-white border-0" id="successSave"
                style="width: fit-content; left: auto; right: 20px; bottom: auto; top: 20px; background: linear-gradient(180deg,#F97F4690 0,#f7497290);">
                <div class="card-header border-white d-flex justify-content-between align-items-center"
                style="border-top-left-radius: 14px !important; border-top-right-radius: 14px !important">
                <span class="text-white"> ${date}</span>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
                </button>
                </div>
                <div class="card-body">
                <p class="text-white">Order Canceled # ${number}</p>
                </div>
            </div>`;
    $(".alertnote").append(x);
    
    var aud = new Audio("/80921__justinbw__buttonchime02up.wav")
    aud.play();
})
connection.start().catch(function (err) {
    return console.error(err.toString());
});

$("#saveneworder").click(function () {
    connection.invoke("SendMessage").catch(function (err) {
        return console.error(err.toString());
    })
});
$(".cancelorder").click(function () {
    connection.invoke("CancelMessage").catch(function (err) {
        return console.error(err.toString());
    })
});

function getNotification() {
    $(".notfy").empty();
    $.ajax({
        url: "/Holds/getNotification",
        method: "GET",
        success: function (result) {
            $(".notfy").html(result);
            var x = $('.notfy li').length;
            $("#ordersNumber").html(x);
        },
        error: function (error) {
            console.log(error);
        }
    });

}
getNotification();

function calcTime() {
    $.ajax({
        url: "/Holds/ChangeStatus",
        method: "POST",
        data: {id:1},
        success: function (orderId) {
            console.log(orderId);
        },
        error: function (error) {
            console.log(error);
        }
    })
};
calcTime();
var con = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();
con.on("message", function (message, date, branchId) {

    let branId = $(".branId").val();
    if (branchId == branId) {
        $(".mnote").empty();
        $(".mnote").html("unreads");
        let mes = `
                             <div class="outgoing_msg">
                                <div class="sent_msg">
                                    <p>${message}</p>
                                    <span class="time_date">${date}</span>
                                </div>
                              </div>`;
        $(".msg_history").append(mes);
    } else {
        $(".mnote").empty();
        $(".mnote").html("unreads");
        $("#bran" + branchId).append("<h6 class='badge badge-info '>Unread Message</h6>")
    }
    var aud = new Audio("/sharp-592.mp3")
    aud.play();

});
con.start().catch(function (err) {
    return console.error(err.toString());
});

$(".done").click(function () {
    let message = $(".text").val();
    let branId = $(".branId").val();
    let date = new Date().toLocaleString();
    let mes = ` <div class="incoming_msg">

                            <div class="received_msg">
                                <div class="received_withd_msg">
                                    <p>${message}</p>
                                    <span class="time_date">${date}</span>
                                </div>
                            </div>
                        </div>`;
    $(".msg_history").append(mes);
    $.ajax({
        url: "/Message/SaveMessage",
        data: { mm: message, bid: branId },
        method: "POST",
        success: function (data) {
            console.log(data);

        },
        error: function (data) {
            console.log(data);
        }
    });
    $(".text").val("");
});
