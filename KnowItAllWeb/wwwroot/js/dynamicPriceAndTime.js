$(function () {
    var inputs = $('#woodInput, #sandInput, #waterInput, #plasticInput, #ironInput, #copperInput, #cottonInput');
    var totalPrice = 0;
    var totalQuantity = 0;

    var prices = {
        wood: 2.5,
        sand: 4,
        water: 2,
        plastic: 4.8,
        iron: 3.3,
        copper: 5.1,
        cotton: 2.95
    };

    function calculateTotalTime(price, quantity) {
        function getTimebyPrice(price) {
            if (price <= 10) {
                return 0;
            } else if (price > 10 && price <= 25) {
                return 7;
            } else if (price > 25 && price <= 100) {
                return 45;
            } else { //price > 100
                return 180;
            }
        }

        function getTimebyQuantity(quantity) {
            if (quantity <= 3) {
                return 0;
            } else if (quantity > 3 && quantity <= 12) {
                return 3;
            } else if (quantity > 12 && quantity <= 50) {
                return 21;
            } else { //quantity > 50
                return 60;
            }
        }

        var timeByPrice = 0;
        var timeByQuantity = 0;

        // Check if any item has a quantity greater than 0
        var anyItemHasQuantity = false;
        inputs.each(function () {
            var quantity = parseFloat($(this).val()) || 0;
            if (quantity > 0) {
                anyItemHasQuantity = true;
                return false; // break out of the each loop
            }
        });

        if (anyItemHasQuantity) {
            timeByPrice = getTimebyPrice(price);
            timeByQuantity = getTimebyQuantity(quantity);
        }

        var totalTime = timeByPrice + timeByQuantity;
        return totalTime;
    }

    // Attach the change event handler to all input fields
    inputs.change(function () {
        // Calculate the total price and quantity
        totalPrice = 0;
        totalQuantity = 0;
        inputs.each(function () {
            var item = $(this).attr('id').replace('Input', '');
            var quantity = parseFloat($(this).val()) || 0;
            if (item !== 'quantity') {
                totalQuantity += quantity; // Add the quantity to the total quantity
                totalPrice += prices[item] * quantity;
            }
        });

        // Update the total price display
        $('#total-price').text(totalPrice.toFixed(2));

        // Calculate the total time
        var totalTime = calculateTotalTime(totalPrice, totalQuantity);

        // Update the total time display
        $('#total-time').text(totalTime);
    });
});
