console.log("site.js loaded!");



$("#makeOrderModalBtn").on("click", function () {
    console.log('t modal');
    $("#makeOrderModal").modal("show");
});

$("#acceptedOffersModal").on("click", function (e) {
    e.stopPropagation();
});

$("#acceptedOffersModalBtn").on("click", function () {
    $("#acceptedOffersModal").modal("show");
});




