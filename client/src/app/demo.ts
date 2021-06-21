let data;

data = '22';
data = 2;

let Car1 = {
    color: 'red',
    model: 'bmw'
};

let Car2 = {
    color: 'blue',
    model: 'mercedes',
    topSpeed: 100
};

console.log(Car2.model);

interface ICar {
    color: string,
    model: string,
    topSpeed?: number
};

let Car3: ICar = {
    color: 'whitle',
    model: 'toyota',
    topSpeed: 200
};

const multiply = (x, y) => {
    return x * y;
}

console.log(multiply(3,4))