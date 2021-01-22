$(document).ready(function(){
    $(".chat-person-list li").click(function(){
        $(".message-box").fadeIn(500);
    });
});

$(document).ready(function(){
    $("#back").click(function(){
        $(".message-box").fadeOut(500);
    });
});