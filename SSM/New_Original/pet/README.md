pet
==============================

Composite of three Python/Cython model units: PotentialEvapotranspiration — simplified Penman-style PET (EEQ from srad, tmax, tmin with albedo and Tmax adjustments; cites Sultani & Sinclair 2012), DryMatterProd — SSM potential dry matter production from intercepted PAR with temperature-modified RUE (outputs DDMP, g m-2 day-1), and PotentialTranspiration — VPD-based potential transpiration using temperatures and daily dry matter (ddmp) scaled by VPDF and TEC.

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

