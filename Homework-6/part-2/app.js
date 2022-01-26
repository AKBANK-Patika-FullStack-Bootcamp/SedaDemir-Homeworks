const girlsPower = (arr) => {
  if (arr.every((n) => typeof n == "number")) {
    const array = arr.map((num) => {
      return girlsPowerAddition(num);
    });
    return `[${arr.join(", ")}] => [${array.join(", ")}]`;
  } else {
    return `Each element must be a number.`;
  }
};

const girlsPowerAddition = (num) => {
  return num / 2 + 3;
};

const array1 = [2, 5, 4];
const array2 = [10, 7, 21];
const array3 = [2, true, 4];
console.log(girlsPower(array1));
console.log(girlsPower(array2));
console.log(girlsPower(array3));
