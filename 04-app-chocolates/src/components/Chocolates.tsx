import { useEffect, useState } from "react";
export default function Chocolate() {
  const [noOfChocolates, setChocolates] = useState(1);
  const [chocolatePrice, setChocolatePrice] = useState(1);

  const addChocolates = function() {
    setChocolatePrice(num2 => num2 + 1);
  }

  useEffect(() => {
    setChocolates(1);
    setChocolatePrice(1);
  }, [])

  return (
    <div className="my-app">
      <h1>Chocolates = {noOfChocolates}</h1>
      <h2>Price = {chocolatePrice}</h2>
      <button onClick={addChocolates}>Add More Chocolates</button>
    </div>
  )
}
