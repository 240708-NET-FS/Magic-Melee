function validateSkill(skillScore) {
  if (isNaN(skillScore)) return false;
  return (
    typeof Number(skillScore) == "number" && skillScore >= 0 && skillScore <= 30
  );
}
export default validateSkill;
