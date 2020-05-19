let selected = null;
let markers = [];

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


setInterval(
    function DisplayFlights() {
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
            let i;
            for (i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
            data.forEach(function (flight) {
                if (selected != null && flight.flight_id == selected.flight_id) {
                    $("#intern_table").append("<tr style=\"background-color: aquamarine\"> <td>" + flight.flight_id + "</td>" + "<td>" + flight.company_name + "</td>" + "<td>" + flight.passengers + "</td></tr>")
                    $("#intern_table").on("click", rowClick(flight))
                } else {
                    $("#intern_table").append(("<tr style=\"background-color: white\" onclick> <td>"
                        + flight.flight_id + "</td>" + "<td>" + flight.company_name + "</td>" + "<td>"
                        + flight.passengers + "</td></tr>").on("click", rowClick(flight)))
                }
                showOnMap(flight);
            });
        });
    }, 2000);

let iconCopy = {
    url: "../images/planeCopy.png", // url
    scaledSize: new google.maps.Size(50, 50), // scaled size
    origin: new google.maps.Point(0, 0), // origin
}
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
    markers.push(marker);

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
    });
}

function rowClick(flight) {
    let flightsUrl = "../api/FlightPlan/" + flight.flight_id;
    let x = new XMLHttpRequest();
    let marker = findMarker(flight);
    x.onreadystatechange = function (marker) {
        if (this.readyState == 4 && this.status == 200) {
            let flightPlan = JSON.parse(x.responseText);
            $.ajax(activate(flight, marker, flightPlan));
        }
    };
    x.open("GET", flightsUrl, true);
    x.send();
}

function findMarker(flight) {
    let i;
    for (i = 0; i < markers.length; i++) {
        if (markers[i].LatLng.lat === flight.latitude && markers[i].LatLng.lng === flight.longitude)
            return markers[i];
    }
}

function generateTable(flight) {
    let table = document.getElementById("tableFlights");
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

function activate(flight, marker, flightPlan) {
    if (selected !== null) {
        reset(selected);
        if (selected.flight_id === flight.flight_id) {
            selected = null;
            return;
        }
    }
    selected = flight;
    showPath(flightPlan);
    generateTable(flight);
    highlightOnTable(flight);
    //changeMarker(marker);
}

function changeMarker(marker) {}

function highlightOnTable(flight) {
    let table = document.getElementById("intern_table");
    for (var i = 0, row; row = table.rows[i]; i++) {
        if (row.cells[0].innerHTML === flight.flight_id) {
            row.style.backgroundColor = "aquamarine";
            break;
        }
    }
}

function reset(selected) {
    resetDetailsTable();
    resetFlightsTable(selected);
    removePath();
}

function resetFlightsTable(selected) {
    let table = document.getElementById("intern_table");
    for (var i = 0, row; row = table.rows[i]; i++) {
        if (row.cells[0].innerHTML === selected.flight_id) {
            row.style.backgroundColor = "white";
            break;
        }
    }
}
function showPath(flightPlan) {
    flightPlanCoordinates = [];
    let path = flightPath.getPath();
    path = [];
    path.push(new google.maps.LatLng(flightPlan.initial_location.latitude, flightPlan.initial_location.longitude));

    flightPath.setPath(path);
    let i;
    for (i = 0; i < flightPlan.segments.length; i++) {
        path.push(new google.maps.LatLng(flightPlan.segments[i].latitude, flightPlan.segments[i].longitude));
        flightPath.setPath(path);
    }
}

function resetDetailsTable() {
    let table = document.getElementById("tableFlights");
    if (table.rows.length > 1)
        table.deleteRow(1);
}
function removePath() {
    let path = flightPath.getPath();
    path = [];
    flightPath.setPath(path);
}