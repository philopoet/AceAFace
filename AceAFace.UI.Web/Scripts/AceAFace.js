var images = [];
var index = 0;
var gameScore = 0;
// Start the animation with JavaScript
function AnimateImage() {
    $("#btnStart").prop('disabled', true);
    LoadImage(index);

    var pictureElement = document.getElementById(images[index].PictureId);
    pictureElement.style.WebkitAnimation = "mymove 8s 1"; // Code for Chrome, Safari and Opera
    pictureElement.style.animation = "mymove 8s 1"; // Standard syntax
    pictureElement.addEventListener("mouseover", PauseDroppingPicture);
}

// Code for Chrome, Safari and Opera

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    if (ev.dataTransfer != null) {
        ev.dataTransfer.setData("text", ev.target.id);
    }
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.parentElement.appendChild(document.getElementById(data));
    PauseDroppingPicture();
    var id = "#" + data;
    $(id).fadeOut("slow");
    var element = document.getElementById(data);
    element.parentNode.removeChild(element);
    EvaluateAnswer(id, ev.target.id);
}


function PauseDroppingPicture() {
    document.getElementById(images[index].PictureId).style.animationPlayState = "paused"
}


function LoadImage(index) {

    var imageSource = "/Images/" + images[index].PictureUrl + ".jpg";
    var img = document.createElement('img');
    img.id = images[index].PictureId;
    img.className = "middle picturesize";
    img.src = imageSource;
    img.setAttribute("draggable", true);
    img.setAttribute("ondragstart", "drag(event)");
    document.getElementById('parent').appendChild(img);
}

function GetImageUrls() {


    $("#btnStart").prop('disabled', true);

    $.ajax({
        url: '/PictureNationalityPuzzle/CreatePicturePuzzle',
        method: 'Post',
        success: function (response) {
            if (response.success) {
                images = response.responseData;
                $("#btnStart").prop('disabled', false);
            } else {
                alert("error");
            }
        },
        error: function (exception) {
            alert(exception);
        }
    });
    debugger;



}
function EvaluateAnswer(pictureId, nationality) {

    var data =
    {
        Nationality: nationality,
        PictureId: pictureId
    }

    $.ajax({
        url: '/PictureNationalityPuzzle/EvaluateAnswer',
        method: 'Post',
        data: data,
        success: function (response) {
            if (response.success) {
                if (response.answerIsValid) {
                    UpdateScore();
                    index++;
                } else {
                    // Wrong Answer
                }
                AnimateImage();
            } else {
                alert("error");
            }
        },
        error: function (exception) {
            alert(exception);
        }
    });
}
function UpdateScore() {
    gameScore++;
    $("#score-text").remove();
    $("#parent").append("<p id='score-text'>Score: " + gameScore + "</p>");
}