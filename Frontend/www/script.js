const saveButton = document.querySelector('#save');
const saveButtonUmum = document.querySelector('#saveu');
const saveButtonTenagaKesehatan1 = document.querySelector('#savetk1');
const saveButtonTenagaKesehatan2 = document.querySelector('#savetk2');
const inputBeratBadan = document.querySelector('#BeratBadan');
const inputTinggi = document.querySelector('#Tinggi');
const inputGulaDarah = document.querySelector('#GulaDarah');
const inputSystolic = document.querySelector('#Systolic');
const inputDiastolic = document.querySelector('#Diastolic');
const inputKolesterol = document.querySelector('#Kolesterol');
const inputNamaObat = document.querySelector('#NamaObat');
const inputKeterangan = document.querySelector('#Keterangan');
const inputWaktu = document.querySelector('#Waktu');

const inputNamaUmum = document.querySelector('#NamaUmum');
const inputTanggalLahirUmum = document.querySelector('#TaggalLahirUmum');
const inputJenisKelaminUmum = document.querySelector('#JenisKelaminUmum');
const inputTeleponUmum = document.querySelector('#TeleponUmum');
const inputEmailUmum = document.querySelector('#EmailUmum');

const inputNamaTenagaKesehatan = document.querySelector('#TenagaKesehatan');
const inputTanggalLahirTenagaKesehatan = document.querySelector('#TaggalLahirTenagaKesehatan');
const inputJenisKelaminTenagaKesehatan = document.querySelector('#JenisKelaminTenagaKesehatan');
const inputTeleponTenagaKesehatan = document.querySelector('#TeleponTenagaKesehatan');
const inputEmailTenagaKesehatan = document.querySelector('#EmailTenagaKesehatan');
const inputNomorSTR = document.querySelector('#NomorSTR');
const inputSpesialis = document.querySelector('#Spesialis');
const inputTempatPraktik = document.querySelector('#TempatPraktik');


function addDiary(BeratBadan, Tinggi, GulaDarah, Systolic, Diastolic, Kolesterol, NamaObat, Keterangan, Waktu) {
    const body = {
        BeratBadan: BeratBadan,
        Tinggi: Tinggi,
        GulaDarah: GulaDarah,
        Systolic: Systolic,
        Diastolic: Diastolic,
        Kolesterol: Kolesterol,
        NamaObat: NamaObat,
        Keterangan: Keterangan,
        Waktu: Waktu,
        isVisible: true
    }
    
    fetch('http://localhost:5168/api/DiaryKesehatan',{
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    .then(data => data.json())
    .then(response => console.log(response));
}

function addUmum(Nama, TanggalLahir, JenisKelamin, Telepon, Email) {
    const body = {
        Nama: Nama,
        TanggalLahir: TanggalLahir,
        JenisKelamin: JenisKelamin,
        Telepon: Telepon,
        Email: Email,
        isVisible: true
    }

    fetch('http://localhost:5168/api/Umum',{
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    .then(data => data.json())
    .then(response => console.log(response));
}

function addTenagaKesehatan(Nama, TanggalLahir, JenisKelamin, TanggalLahir, Telepon, Email, NomorSTR, Spesialis, TempatPraktik) {
    const body = {
        Nama: Nama,
        TanggalLahir: TanggalLahir,
        JenisKelamin: JenisKelamin,
        Telepon: Telepon,
        Email: Email,
        NomorSTR: NomorSTR,
        Spesialis: Spesialis,
        TempatPraktik: TempatPraktik,
        isVisible: true
    }

    fetch('http://localhost:5168/api/TenagaKesehatan',{
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    .then(data => data.json())
    .then(response => console.log(response));
}

function addTenagaKesehatan(NomorSTR, Spesialis, TempatPraktik) {
    const body = {
        NomorSTR: NomorSTR,
        Spesialis: Spesialis,
        TempatPraktik: TempatPraktik,
        isVisible: true
    }

    fetch('http://localhost:5168/api/TenagaKesehatan',{
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    .then(data => data.json())
    .then(response => console.log(response));
}


saveButton.addEventListener('click', function() {
    addDiary(inputBeratBadan, inputTinggi, inputGulaDarah, inputSystolic, inputDiastolic, inputKolesterol, inputNamaObat, inputKeterangan, inputWaktu);
})
saveButtonUmum.addEventListener('click', function() {
    addDiary(inputNamaUmum, inputTanggalLahirUmum, inputJenisKelaminUmum, inputTeleponUmum, inputEmailUmum);
})
saveButtonTenagaKesehatan1.addEventListener('click', function() {
    addDiary(inputNamaTenagaKesehatan, inputTanggalLahirTenagaKesehatan, inputJenisKelaminTenagaKesehatan, inputTeleponTenagaKesehatan, inputEmailTenagaKesehatan)
})
saveButtonTenagaKesehatan2.addEventListener('click', function() {
    addDiary(inputNomorSTR, inputSpesialis, inputTempatPraktik)
})