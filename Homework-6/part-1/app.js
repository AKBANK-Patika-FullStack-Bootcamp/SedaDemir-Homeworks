import { Dog } from "./dog.js";
import { Bath, dogCareTime } from "./dogCareUtility.js";

const myPuppy = new Dog("Cinnamon", 2, 50, 5);
myPuppy.age = 6;
console.log("******* My Dog's Info *******");
console.log(
  `Your beloved puppy ${myPuppy.name} is ${myPuppy.age} years old, ${myPuppy.height}cm high and weights ${myPuppy.weight} kg.`
);
console.log(Bath());
console.log(`Your dog's care takes ${dogCareTime} hours. `);
