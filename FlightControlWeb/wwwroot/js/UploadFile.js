function submit1(file) {
    let name = document.getElementById("myFile");
    let todo = { "Id": 0, "IsComplete": false, "Name": name }
    let postOptions = preparePost(todo)
        //This uses the promises API: https://javascript.info/promise-basicsfetch
        //("../api/FlightPlan/", postOptions)
        // reads the body of the response as json
        //.then(response => response.json()).
        //then(appendItem).
        //catch(error => console.log(error));
    let flightURL = "../api/FlightPlan";
    let xhr = new XMLHttpRequest();
    xhr.open("POST", flightURL, true);
    xhr.setRequestHeader("content-type", "application/json");
    xhr.send(name);
}
let ContentType = "application/json";
function preparePost(todo) {
    let todoAsStr = JSON.stringify(todo);
    return {
        "method": "POST",
        "headers": { 'Content-Type': ContentType },
        "body": todoAsStr
    }
}
document.getElementById('import').onclick = function () {
    var files = document.getElementById('selectFiles').files;
    console.log(files);
    if (files.length <= 0) {
        return false;
    }

    var fr = new FileReader();

    fr.onload = function (e) {
        console.log(e);
        var result = JSON.parse(e.target.result);
        var formatted = JSON.stringify(result, null, 2);
        document.getElementById('result').value = formatted;
    }

    fr.readAsText(files.item(0));
};