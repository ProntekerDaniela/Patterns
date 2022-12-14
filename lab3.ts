type Resident = {
  fullName: string;
  sex: 'male' | 'female';
  dateOfBirth: string;
};

type Flat = { residents: Resident[] };

type IBuildingVisitor = {
  visitPrivateBuilding(_: PrivateBuilding): void;
  visitApartmentBuilding(_: ApartmentBuilding): void;
};

class PrivateBuilding {
  residents: Resident[];
  constructor(residents: Resident[]) {
    this.residents = residents;
  }
  accept(visitor: IBuildingVisitor) {
    visitor.visitPrivateBuilding(this);
  }
}

class ApartmentBuilding {
  flats: Flat[];
  constructor(flats: Flat[]) {
    this.flats = flats;
  }
  accept(visitor: IBuildingVisitor) {
    visitor.visitApartmentBuilding(this);
  }
}

class MilitaryCommissariatVisitor implements IBuildingVisitor {
  private getAge(dateString: string) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }

  private processResidents(residents: Resident[]) {
    for (const resident of residents) {
      const age = this.getAge(resident.dateOfBirth);
      if (age >= 18 && age <= 27 && resident.sex === 'male') {
        console.log(`${resident.fullName} : ${age} : ${resident.sex}`);
      }
    }
  }

  visitApartmentBuilding(apartmentBuilding: ApartmentBuilding): void {
    for (const flat of apartmentBuilding.flats) {
      this.processResidents(flat.residents);
    }
  }

  visitPrivateBuilding(privateBuilding: PrivateBuilding): void {
    this.processResidents(privateBuilding.residents);
  }
}

class CensusServiceVisiter implements IBuildingVisitor {
  private calculateTotalNumberOfResidents(residents: Resident[]) {
    const totalNumber = residents.length;
    console.log(`Total number of residents is ${totalNumber}`);
  }

  visitApartmentBuilding(apartmentBuilding: ApartmentBuilding): void {
    let residents = apartmentBuilding.flats.reduce<Resident[]>(
      (allResidents, flat) => [...allResidents, ...flat.residents],
      []
    );
    this.calculateTotalNumberOfResidents(residents);
  }

  visitPrivateBuilding(privateBuilding: PrivateBuilding): void {
    this.calculateTotalNumberOfResidents(privateBuilding.residents);
  }
}

const buildings: (PrivateBuilding | ApartmentBuilding)[] = [
  new PrivateBuilding([
    {
      dateOfBirth: '1993-10-11T19:56:13.560Z',
      fullName: 'Pavlo',
      sex: 'male',
    },
    {
      dateOfBirth: '2003-10-11T19:56:13.560Z',
      fullName: 'Karina',
      sex: 'female',
    },
    {
      dateOfBirth: '1990-10-11T19:56:13.560Z',
      fullName: 'Olexandra',
      sex: 'female',
    },
  ]),
  new ApartmentBuilding([
    {
      residents: [
        {
          dateOfBirth: '1986-10-11T19:56:13.560Z',
          fullName: 'Petro',
          sex: 'male',
        },
        {
          dateOfBirth: '2001-10-11T19:56:13.560Z',
          fullName: 'Anna',
          sex: 'female',
        },
      ],
    },
    {
      residents: [
        {
          dateOfBirth: '2009-10-11T19:56:13.560Z',
          fullName: 'Igor',
          sex: 'female',
        },
      ],
    },
  ]),
];

const proceedBuildings = () => {
  for (const building of buildings) {
    building.accept(new MilitaryCommissariatVisitor());
    building.accept(new CensusServiceVisiter());
  }
};

proceedBuildings();
