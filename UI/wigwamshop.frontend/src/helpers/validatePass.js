import PasswordValidator from "password-validator";

const schema = new PasswordValidator();

schema
    .is()
    .min(6)
    .is()
    .max(20)
    .has()
    .uppercase()
    .has()
    .lowercase()
    .has()
    .digits()
    .has()
    .not()
    .spaces()
    .has()
    .symbols();

export default schema;
