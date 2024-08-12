import validateScore from "../validateScore";
import validateSkill from "../validateSkill";
import { it, test, expect } from "@jest/globals";
describe("score and skill validators", () => {
  describe("Skill validator", () => {
    it("Permits valid score values", () => {
      const testScore = 10;
      const isValid = validateSkill(testScore);
      expect(isValid).toBe(true);
    });
    it("does not allow NaN values", () => {
      const NaNstring = "hello";
      const NaNValue = Number(NaNstring);
      expect(validateSkill(NaNValue)).toBe(false);
    });

    it("Does now allow greater than 30", () => {
      const testSkillScore = 31;

      const isValid = validateSkill(testSkillScore);
      expect(isValid).toBe(false);
    });
  });

  describe("Ability Score validator", () => {
    it("Permits valid score values", () => {
      const testScore = 10;
      const isValid = validateSkill(testScore);
      expect(isValid).toBe(true);
    });

    it("does not allow NaN values", () => {
      const NaNstring = "hello";
      const NaNValue = Number(NaNstring);
      expect(validateScore(NaNValue)).toBe(false);
    });

    it("Does now allow greater than 20", () => {
      const testAbilityScore = 21;

      const isValid = validateScore(testAbilityScore);
      expect(isValid).toBe(false);
    });
  });
});
