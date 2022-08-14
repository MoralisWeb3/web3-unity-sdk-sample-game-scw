const hre = require("hardhat");
const fs = require('fs');

async function main()
{

    ///////////////////////////////////////////////////////////
    // DEPLOYMENT
    ///////////////////////////////////////////////////////////
    const Property = await hre.ethers.getContractFactory("Property");
    const property = await Property.deploy();
    await property.deployed();


    ///////////////////////////////////////////////////////////
    // UNITY-FRIENDLY OUTPUT
    ///////////////////////////////////////////////////////////
    const abiFile = JSON.parse(fs.readFileSync('./artifacts/contracts/Property.sol/Property.json', 'utf8'));
    const abi = JSON.stringify(abiFile.abi).replaceAll ('"','\\"',);
    console.log("\n");
    console.log("DEPLOYMENT COMPLETE");
    console.log("		_address  = \"%s\";", property.address);
    console.log("		_abi      = \"%s\";", abi);
    console.log("\n");

    ///////////////////////////////////////////////////////////
    // WAIT
    ///////////////////////////////////////////////////////////
    console.log("WAIT...");
    console.log("\n");
    await property.deployTransaction.wait(5);


    ///////////////////////////////////////////////////////////
    // VERIFY
    ///////////////////////////////////////////////////////////
    await hre.run("verify:verify", {
        address: property.address,
        constructorArguments: [],
    });


    ///////////////////////////////////////////////////////////
    // LOG OUT DATA FOR USAGE IN UNITY
    ///////////////////////////////////////////////////////////
    console.log("VERIFICATION COMPLETE");
    console.log("\n");

}

///////////////////////////////////////////////////////////
// EXECUTE
///////////////////////////////////////////////////////////
main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
