function saveStatusUpdate() {
    var input = document.querySelector("#message");
    var val = input.value;

    $.post("/Home/postUpdate", { text: val }, function (result) {
        if (result) {
         
        }
        //$(".js-tooltip").html(val); //aq appendis gamoyeneba

    });
}




function saveComment() {
    // aigeb parent postis id
    var postId;
    // aigeb daweril komsentars
    var commentText;

    // sigeb damwer iuzeris id
    var userId;
    

    $.post("/Home/CommentUpdate", { postId: postId,commentText:commentText,userId:userId }, function (result) {
        if (result) {


        }

    });
}