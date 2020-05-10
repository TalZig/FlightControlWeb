// Empty JS for your own code to be here
function onDrop(ev) {
    ev.preventDefault();
    document.getElementById("details").innerHTML = "drop";
    document.getElementById("dragAndDrop").style.display = "none";
    $("#dragArea").show();
    if (ev.dataTransfer.items[0].kind === 'file') {
        let file = ev.dataTransfer.items[0].getAsFile();
        document.getElementById("details").innerHTML = file.name;
        let flightURL = "../api/FlightPlan";
    }
}
function onDragOver(ev) {
    $("#dragArea").hide();
    $("#dragAndDrop").show();
    ev.preventDefault();
    event.dataTransfer.setData("text/plain", event.target.id);
    document.getElementById("details").innerHTML = "drag";
}