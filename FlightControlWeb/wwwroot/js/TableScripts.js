function initializeTable() {
    let internTable = document.getElementById('intern_table');
    let d = new Date();
    let dateTime = d.getFullYear().toString();
    dateTime = dateTime.concat("-");
    let month = d.getMonth() + 1;
    if (month < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(month.toString());
    dateTime = dateTime.concat("-");
    let day = d.getDate();
    if (day < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(day.toString());
    dateTime = dateTime.concat("T");
    if (dateTime < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getHours().toString());
    dateTime = dateTime.concat(":");
    if (dateTime < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getMinutes().toString());
    dateTime = dateTime.concat(":");
    if (dateTime < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getSeconds().toString());
    dateTime = dateTime.concat("Z");
    console.log(dateTime);

    let request = new XMLHttpRequest();
    /*request.onreadystatechange = function() {
        if (this.readyState === 4 && this.status === 200) {
            console.log(this.responseText);
        }
    };*/
    request.open("GET", "../api/Flight?relative_to=<" + dateTime +">", true);
    request.onload = parse(request);
    request.send();
    parse(request);
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



function DisplayFlights() {
    let internTable = document.getElementById('intern_table');
    //get the date and put in the pattern.
    let d = new Date();
    let dateTime = d.getFullYear().toString();
    dateTime = dateTime.concat("-");
    let month = d.getMonth() + 1;
    if (month < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(month.toString());
    dateTime = dateTime.concat("-");
    let day = d.getDate();
    if (day < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(day.toString());
    dateTime = dateTime.concat("T");
    if (d.getHours() < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getHours().toString());
    dateTime = dateTime.concat(":");
    if (d.getMinutes() < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getMinutes().toString());
    dateTime = dateTime.concat(":");
    if (d.getSeconds() < 10)
        dateTime = dateTime.concat("0");
    dateTime = dateTime.concat(d.getSeconds().toString());
    dateTime = dateTime.concat("Z");
    console.log(dateTime);
    //edit the command
    let flightsUrl = "../api/Flight?relative_to=<" + dateTime + ">"
    //get data from the server
    $.getJSON(flightsUrl, function (data) {
        //initialize the flights table (removing the old flights).
        let table = document.getElementById("intern_table");
        table.innerHTML = "";
        //adding the new flights to the intern_table, moving flight by flight with for-each loop.
        data.forEach(function (flight) {
            $("#intern_table").append("<tr ><td>" + flight.flight_id + "</td>" + "<td>" + flight.company_name + "</td>" + "<td>" + flight.passengers  +"</td></tr>")
        });
    });
}
//initializeTable();