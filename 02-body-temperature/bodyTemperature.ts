const https = require('https');


interface RecordInfo {
    doctor: {
        name: string;
    };
    diagnosis: {
        id: number;
    };
    vitals: {
        bodyTemperature: number;
    };
}
interface DataInfo {
    data: RecordInfo[];
    total_pages: number;

}

async function fetchPage(url): Promise<DataInfo> {
    return new Promise((resolve, reject) => {
        https.get(url, (res) => {
            let data = '';
            res.on('data', (chunk) => {
                data += chunk;
            });
            res.on('end', () => {
                try {
                    resolve(JSON.parse(data));
                } catch (error) {
                    reject(error);
                }
            });
        }).on('error', (error) => reject(error));
    });
}

async function bodyTemperature(doctorName, diagnosticId) {
    const baseUrl = 'https://jsonmock.hackerrank.com/api/medical_records';
    let page = 1;
    let totalPages = 1;
    let temperatures: number[] = [];

    try {
        while (page <= totalPages) {
            const response: DataInfo = await fetchPage(`${baseUrl}?page=${page}`);
            const { data, total_pages } = response;
            totalPages = total_pages;

            // console.log(data);
            
            data.forEach(record => {
                if (
                    record.doctor.name === doctorName &&
                    record.diagnosis.id === diagnosticId
                ) {
                    if (record.vitals.bodyTemperature !== undefined && record.vitals.bodyTemperature !== null) {
                        temperatures.push(record.vitals.bodyTemperature);
                    }
                }
            });

            page++;
        }
    } catch (error) {
        console.error('Error fetching data:', error);
        return [null, null];
    }

    if (temperatures.length === 0) {
        return [null, null];
    }

    return [Math.floor(Math.min(...temperatures)), Math.floor(Math.max(...temperatures))];
}

// Ejemplo de uso
(async () => {
    const result = await bodyTemperature('Dr Allysa Ellis', 2);
    console.log(result);
})();
