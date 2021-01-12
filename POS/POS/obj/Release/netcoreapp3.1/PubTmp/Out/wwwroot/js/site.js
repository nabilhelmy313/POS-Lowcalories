//send notifications
var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();
connection.on("NewOrder", function (number, date) {
    var x = $('.notfy li').length;
    $("#ordersNumber").empty();
    $("#ordersNumber").html(x);
    var li = `<li class='m-2'>
                                <span>${date}</span>
                                <span>${number}</span>
                                <hr />
                            </li>`;
    $(".notfy").append(li);
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});

$("#saveneworder").click(function () {
    connection.invoke("SendMessage", 1, 2).catch(function (err) {
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