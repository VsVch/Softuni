function solve(area, vol, input) {

    let inputElements = JSON.parse(input);

    let result = [];

    //console.log(inputElements);
    for (const inputElement of inputElements) {

        let object = {
            area: area.call(inputElement),
            volume: vol.call(inputElement)
        }
        result.push(object);
    }

    return result;
}