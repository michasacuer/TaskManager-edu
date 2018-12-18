export default {
  check(str) {
    return {
      hasNumber: () => /\d/.test(str),

      isEmailValid: () => /\S+@\S+\.\S+/.test(str),

      firstLetterCapital: () => str.charAt(0).toUpperCase() + str.slice(1)
    };
  }
};
