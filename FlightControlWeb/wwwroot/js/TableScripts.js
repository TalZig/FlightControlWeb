function initializeTable() {
    let internTable = document.getElementById('intern_table');
    let d = new Date();
    let dateTime = d.getFullYear().toString();
    dateTime = dateTime.concat("-");
    dateTime = dateTime.concat((d.getMonth() + 1).toString());
    dateTime = dateTime.concat("-");
    dateTime = dateTime.concat((d.getDay()).toString());
    dateTime = dateTime.concat("T");
    dateTime = dateTime.concat(d.getHours().toString());
    dateTime = dateTime.concat(":");
    dateTime = dateTime.concat(d.getMinutes().toString());
    dateTime = dateTime.concat(":");
    dateTime = dateTime.concat(d.getSeconds().toString());
    dateTime = dateTime.concat("Z");
    console.log(dateTime);

    let request = new XMLHttpRequest();
    request.onreadystatechange = function() {
        if (this.readyState === 4 && this.status === 200) {
            console.log(this.responseText);
        }
    };
    request.open("GET", "/api/Flights?relative_to<" + dateTime + ">", true);
    //request.onload = parse(request);
    request.send();
}


function parse(request) {
    try {
        const json = JSON.parse(request.responseText);
        populateTable(json);
    } catch (e) {
        console.warn("Can't upload table!");
    }
}

function populateTable(json) {
    console.log(json);
}

initializeTable();