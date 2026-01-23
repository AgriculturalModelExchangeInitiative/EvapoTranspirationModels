pet
==============================

Computes daily potential evapotranspiration (PET, mm d−1) following Soltani & Sinclair (2012) using an equilibrium evaporation (EEQ) term adjusted by temperature-dependent multipliers. Average daytime temperature is TD = 0.6·Tmax + 0.4·Tmin. The surface albedo blends crop and soil albedos weighted by the fraction of surface energy reaching soil, exp(−KET·ETLAI): ALBEDO = CALB·(1 − exp(−KET·ETLAI)) + SALB·exp(−KET·ETLAI). EEQ is then EEQ = SRAD·(0.004876 − 0.004374·ALBEDO)·(TD + 29). PET is derived from EEQ with three regimes: PET = 1.1·EEQ for 5 < Tmax < 34; PET = EEQ·((Tmax − 34)·0.05 + 1.1) for Tmax ≥ 34 (advection); PET = EEQ·0.01·exp(0.18·(Tmax + 20)) for Tmax ≤ 5 (cold/frozen conditions). The uncovered-soil fraction follows the Beer–Bouguer–Lambert law via ETLAI and KET. Methodology relates to Priestley–Taylor (1972) and the modifications summarized by Ritchie (1998) as presented in Soltani & Sinclair (2012).

Project Organization
------------

```

    ├── LICENSE.txt        <- License file
    ├── README.md          <- The top-level README for AMEI members using this project.
    ├── data/              <- data used for model simulation
    │
    ├── doc/               <- Package documentation
    │
    ├── test/             <- model tests for each language and platform
    │
    ├── crop2ml/          <- model units and composite in crop2ml format.
    │      ├── xml files
    │      ├── Algo/      <- in different languages
    |
    │
    ├── src/                <- Executable source in different language and platform
    │   ├── pyx/
    │   ├── java/
    │   ├── py/
        ├── R/
        ├── cpp/
        ├── cs/
        ├── f90/
        ├── Bioma/
        ├── Simplace/
        ├── OpenAlea/
        ├── Record/
   
```

