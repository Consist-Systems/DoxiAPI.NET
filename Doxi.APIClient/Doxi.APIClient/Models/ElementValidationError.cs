namespace Doxi.APIClient
{
    public enum ElementValidationError
    {
        Email_is_not_valid = 4,
        Id_number_is_not_valid = 5,
        Phone_number_is_not_valid = 6,
        License_plate_is_not_valid = 7,
        Postal_code_is_not_valid = 8,
        There_are_mandatory_elements = 10,
        Char_is_smaller_than_minimum = 11,
        Char_is_bigger_than_maximum = 12,
        Date_is_smaller_than_minimum_date = 13,
        Date_is_bigger_than_maximum_date = 14,
        Credit_card_is_not_valid = 15,
        Cw_credit_card_is_not_valid = 16,
        Number_is_smaller_than_minimum = 17,
        Number_is_bigger_than_maximum = 18,
        There_are_required_elements = 19
    }
}
