$('#accept-selected').click(function () {

    console.log("accept offers script loaded!");

    var selectedOffers = [];
    $('input[name="offer.OfferStatus"]:checked').each(function () {
        selectedOffers.push($(this).val());
    });

    if (selectedOffers.length > 0) {
        $.ajax({
            type: 'POST',
            /*   url: '@Url.Action("AcceptSelectedOffers", "HomeController")',*/
            url: '/Home/AcceptSelectedOffers',
            data: { offerIds: selectedOffers },
            success: function (response) {
                alert(response);
                location.reload(); // Reload the page to update the offer status
            },
            error: function () {
                alert('Error occurred while accepting offers.');
            }
        });
    } else {
        alert('No offers selected for acceptance.');
    }
});
