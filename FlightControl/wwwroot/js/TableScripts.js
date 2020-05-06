// Empty JS for your own code to be here
function onDrop(ev) {
    document.getElementById("details").innerHTML = "drop";
    document.getElementById("dragAndDrop").style.display = "none";
    $("#dragArea").show();
    ev.preventDefault();
    if (ev.dataTransfer.items[0].kind === 'file') {
        let file = ev.dataTransfer.items[0].getAsFile();
        document.getElementById("details").innerHTML = file.name;
        let flightURL = "../api/FlightPlan";
    }
    /*console.log('File(s) dropped');

    // Prevent default behavior (Prevent file from being opened)
    ev.preventDefault();

    if (ev.dataTransfer.items) {
        // Use DataTransferItemList interface to access the file(s)
        for (var i = 0; i < ev.dataTransfer.items.length; i++) {
            // If dropped items aren't files, reject them
            if (ev.dataTransfer.items[i].kind === 'file') {
                var file = ev.dataTransfer.items[i].getAsFile();
                console.log('... file[' + i + '].name = ' + file.name);
            }
        }
    } else {
        // Use DataTransfer interface to access the file(s)
        for (var i = 0; i < ev.dataTransfer.files.length; i++) {
            console.log('... file[' + i + '].name = ' + ev.dataTransfer.files[i].name);
        }
    }*/
}

function onDragOver(ev) {
    $("#dragArea").hide();
    $("#dragAndDrop").show();
    ev.preventDefault();
    event.dataTransfer.setData("text/plain", event.target.id);
    document.getElementById("details").innerHTML = "drag";
}