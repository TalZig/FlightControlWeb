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

function getDateTime() {
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
    return dateTime;
}


function DisplayFlights() {
    let internTable = document.getElementById('intern_table');
    //get the date and put in the pattern.
    let dateTime = getDateTime();
    //edit the command
    let flightsUrl = "../api/Flight?relative_to=<" + dateTime + ">"
    //get data from the server
    $.getJSON(flightsUrl, function (data) {
        //initialize the flights table (removing the old flights) .
        let table = document.getElementById("intern_table");
        table.innerHTML = "";
        //adding the new flights to the intern_table, moving flight by flight with for-each loop .
        let header = table.createTHead();
        let row = header.insertRow();
        let c0 = row.insertCell(0);
        c0.innerHTML = "Flight.ID";
        c0.style.fontWeight = 'bold'
        let c1 = row.insertCell(1);
        c1.innerHTML = "Company";
        c1.style.fontWeight = 'bold'
        let c2 = row.insertCell(2);
        c2.innerHTML = "Passengers";
        c2.style.fontWeight = 'bold'
        data.forEach(function (flight) {
            $("#intern_table").append("<tr ><td>" + flight.flight_id + "</td>" + "<td>" + flight.company_name + "</td>" + "<td>" + flight.passengers + "</td></tr>")
            showOnMap(flight);
        });
    });
}
let iconCopy = {
    url: "../images/planeCopy.png", // url
    scaledSize: new google.maps.Size(50, 50), // scaled size
    origin: new google.maps.Point(0, 0), // origin
}
//let markers = {};
function showOnMap(flight) {
    let icon = {
        url: "../images/plane.png", // url
        scaledSize: new google.maps.Size(50, 50), // scaled size
        origin: new google.maps.Point(0, 0), // origin
    };
    let posi = { lat: flight.latitude, lng: flight.longitude };
    let marker = new google.maps.Marker({
        position: { lat: flight.latitude, lng: flight.longitude },
        map: map,
        title: flight.flight_id,
        icon: icon
    });
    //markers[posi] = flight.flight_id;


    let infowindow = new google.maps.InfoWindow({
        content: '<p>Marker Location:' + marker.getPosition() + '</p>'
            + '<p>Flight ID:' + flight.flight_id + '</p>'
    });

    google.maps.event.addListener(marker, 'click', function (marker) {
        let flightsUrl = "../api/FlightPlan/" + flight.flight_id;
        let x = new XMLHttpRequest();
        x.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                let flightPlan = JSON.parse(x.responseText);
                $.ajax(activate(flight, marker, flightPlan));
            }
        };
        x.open("GET", flightsUrl, true);
        x.send();
        /*$.ajax({
            url: flightsUrl,
            dataType: "jsonP",
            success: function (data) {
                console.log("check");
                data.forEach(function (flight1) {
                    $("#tableFlights").append("<tr ><td>" + flight.flight_id + "</td>" + "<td>" + flight1.longitude + "</td>" + "<td>" + flight1.latitude + "</td>" + "<td>" + flight1.passengers + "</td>" + "<td>" + flight1.company_name + "<td>" + flight1.date_time + "</td>" + "<td>" + flight1.is_external + "</td>" + "</td></tr>")
                    //showOnMap(flight);
                });
            }
        });*/
    });
}

function generateTable(flight) {
    let table = document.getElementById("tableFlights");
    if (table.rows.length > 1) {
        let id = table.rows[1].cells[0]
        if (id.innerHTML == flight.flight_id) {
            table.deleteRow(1);
            return;
        }
        table.deleteRow(1);
    }
    let row = table.insertRow(1);
    let c0 = row.insertCell(0);
    c0.innerHTML = flight.flight_id;
    let c1 = row.insertCell(1);
    c1.innerHTML = flight.longitude;
    let c2 = row.insertCell(2);
    c2.innerHTML = flight.latitude;
    let c3 = row.insertCell(3);
    c3.innerHTML = flight.passengers;
    let c4 = row.insertCell(4);
    c4.innerHTML = flight.company_name;
    let c5 = row.insertCell(5);
    c5.innerHTML = flight.date_time;
    let c6 = row.insertCell(6);
    c6.innerHTML = flight.is_external;
}
let selected = null;
function activate(flight, marker, flightPlan) {
    /*if (selected !== null) {
        reset(selected);
        if (selected.flight_id === flight.flight_id)
            return;
    }*/
    generateTable(flight);
    //highlightOnTable(flight);
    changeMarker(marker);
    //showPath(flightPlan);
}

function changeMarker(marker) {
    marker.setIcon(iconCopy);
    //marker.srcElement = "../images/planeCopy.png";
}

function highlightOnTable(flight) {
    let table = document.getElementById("intern_table");
    for (var i = 0, row; row = table.rows[i]; i++) {
        if (row.cells[0].innerHTML === flight.flight_id) {
            row.addClass("table-success");
            break;
        }
    }
}