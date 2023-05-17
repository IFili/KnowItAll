document.querySelector('#make-order-form').addEventListener('submit', function (event) {
    event.preventDefault(); // prevent form submission so we can validate first

    const wood = parseInt(document.querySelector('#woodInput').value);
    const sand = parseInt(document.querySelector('#sandInput').value);
    const water = parseInt(document.querySelector('#waterInput').value);
    const plastic = parseInt(document.querySelector('#plasticInput').value);
    const iron = parseInt(document.querySelector('#ironInput').value);
    const copper = parseInt(document.querySelector('#copperInput').value);
    const cotton = parseInt(document.querySelector('#cottonInput').value);

    let valid = true;
    let errorMessage = '';

    const itemCount = [wood, sand, water, plastic, iron, copper, cotton].filter(x => x > 0).length;
    if (itemCount < 2) {
        valid = false;
        errorMessage += 'You must order at least two different items.\n';
    }

    if (sand > 0 && water < 2 * sand) {
        valid = false;
        errorMessage += 'For every sand, you must have at least 2 waters.\n';
    }

    if (cotton > 0 && water < 3 * cotton) {
        valid = false;
        errorMessage += 'For every cotton, you must have at least 3 waters.\n';
    }

    if (valid) {
        // form is valid, so submit it
        this.submit();
    } else {
        // show error message and don't submit form
        alert(errorMessage);
    }
});
