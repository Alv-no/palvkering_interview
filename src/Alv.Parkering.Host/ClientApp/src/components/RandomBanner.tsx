import React, { useMemo } from "react";
const RANDOM_STRINGS = ["Fordi bil i Olso er vanskelig",
                        "Klingen mista bilen sin i Oslo",
                        "Fordi bøter er kjipt",
                        "Hvem trenger easypark når man kan parkere gratis",
                        "Min favorittsang er 'Jeg vil være en Alv'",
                        "Bil i Oslo er en god ide",
];

export const RandomBanner = () => {

    const randomIndex = useMemo(() => {
        return Math.floor(Math.random() * RANDOM_STRINGS.length);
    }, []);

    return (
        <>{RANDOM_STRINGS[randomIndex]}</>
    )
}
