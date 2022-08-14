///////////////////////////////////////////////////////////
// REQUIRES
///////////////////////////////////////////////////////////
const hre = require("hardhat");
const fs = require('fs');

///////////////////////////////////////////////////////////
// MAIN
///////////////////////////////////////////////////////////
async function main()
{

  ///////////////////////////////////////////////////////////
  // DEPLOYMENT
  ///////////////////////////////////////////////////////////

  // TheGameLibrary
  const TheGameLibrary = await ethers.getContractFactory("TheGameLibrary");
  const theGameLibrary = await TheGameLibrary.deploy();
  await theGameLibrary.deployed();

  // Property
  const Property = await ethers.getContractFactory("Property", {
    libraries: {
        TheGameLibrary: theGameLibrary.address,
    },
  });
  const property = await Property.deploy();
  await property.deployed();


  ///////////////////////////////////////////////////////////
  // UNITY-FRIENDLY OUTPUT
  ///////////////////////////////////////////////////////////
  const abiFile = JSON.parse(fs.readFileSync('./artifacts/contracts/Property.sol/Property.json', 'utf8'));
  const abi = JSON.stringify(abiFile.abi).replaceAll ('"','\\"',);
  console.log("\n");
  console.log("DEPLOYMENT COMPLETE: COPY TO UNITY...");
  console.log("\n");
  console.log("       protected override void SetContractDetails()");
  console.log("       {\n");
  console.log("         _treasurePrizeContractAddress  = \"%s\";", treasurePrize.address);
  console.log("         _address  = \"%s\";", theGameContract.address);
  console.log("         _abi      = \"%s\";\n", abi);
  console.log("       }\n");
  console.log("\n");


  ///////////////////////////////////////////////////////////
  // WAIT
  ///////////////////////////////////////////////////////////
  console.log("WAIT ...");
  console.log("\n");
  await theGameContract.deployTransaction.wait(7);


  ///////////////////////////////////////////////////////////
  // VERIFY
  ///////////////////////////////////////////////////////////
  console.log("VERIFICATION STARTING ...");
  console.log("\n");
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
