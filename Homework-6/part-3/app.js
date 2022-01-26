const Reverse1 = (str) => {
  return str.split("").reverse().join("");
};

// Most optimal method below as it has O(N) time but it is longer and boring.
const Reverse2 = (str) => {
  let reversedStr = "";
  for (let i = str.length - 1; i >= 0; i--) {
    reversedStr += str[i];
  }
  return reversedStr;
};

const Reverse3 = (str) => {
  return Array.from(str).reverse().join("");
};

const Reverse4 = (str) => {
  let newStr = [];
  for (const letter of str) {
    newStr.unshift(letter);
  }
  return newStr.join("");
};

console.log(Reverse1("this"));
console.log(Reverse2("is"));
console.log(Reverse3("string"));
console.log(Reverse4("reversing"));
