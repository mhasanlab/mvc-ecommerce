//// Morris.js Charts sample data for SB Admin template

//AREA : Sales per Day
$(document).ready(
    function () {
        var url = "/Dashboard/GetSalesPerDay";
        $.get(url, function (a) {
            new Morris.Area({
                element: 'morris-area-chart',
                data: a,
                xkey: 'period',
                ykeys: ['sales'],
                labels: ['Sales'],
                pointSize: 2,
                hideHover: 'auto',
                resize: true
            })
        })
    });

//CIRCLE: Top 3 Sold Products
$(document).ready(
    function () {
    var url = "/Dashboard/GetTopProductSales";
    $.get(url, function (res) {
        new Morris.Donut({
            element: 'morris-donut-chart',
            data: res,
            resize: true
        })
    })
    }
);



//LINE: Most orders per day
$(document).ready(
    function () {
        var url = "/Dashboard/GetOrderPerDay";
        $.get(url, function (res) {
            new Morris.Line({
                element: 'morris-line-chart',
                data: res,
                xkey: 'Date',             
                ykeys: ['Orders'],            
                labels: ['Orders'],              
                smooth: false,
                resize: true
            })
        })
    }
);



//BAR : Most sales in country
$(document).ready(
    function () {
        var url = "/Dashboard/GetSalesPerCountry";
        $.get(url, function (res) {
            new Morris.Bar({
                element: 'morris-bar-chart',
                data: res,
                xkey: 'Country',
                ykeys: ['Sales_Amount'],
                labels: ['Sales Amount'],
                barRatio: 0.4,
                xLabelAngle: 35,
                hideHover: 'auto',
                resize: true
            })
        })
    }
);
