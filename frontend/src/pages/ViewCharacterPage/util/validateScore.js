function validateScore(score) {
  if (isNaN(score)) return false;
  return typeof Number(score) == "number" && score > 0 && score <= 20;
}

export default validateScore;
