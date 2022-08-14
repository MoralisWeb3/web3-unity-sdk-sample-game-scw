///////////////////////////////////////////////////////////
// REQUIRES
///////////////////////////////////////////////////////////
require("dotenv").config();
require("@nomicfoundation/hardhat-toolbox");
require("hardhat-gas-reporter");

///////////////////////////////////////////////////////////
// EXPORTS
///////////////////////////////////////////////////////////

/**
 * @type import('hardhat/config').HardhatUserConfig
 */
module.exports = {
  solidity: "0.8.9",
  networks: {
    hardhat: {},
    cronosTestnet: {
      url: "https://evm-t3.cronos.org/",
      chainId: 338,
      accounts: [process.env.WEB3_WALLET_PRIVATE_KEY],
      gasPrice: 5000000000000
    }
  },
  etherscan: {
    apiKey: {
      cronosTestnet: process.env.CRONOSCAN_TESTNET_API_KEY
    },
    customChains: [
      {
        network: "cronosTestnet",
        chainId: 338,
        urls: {
            apiURL: "https://api-testnet.cronoscan.com/api",
            browserURL: "https://testnet.cronoscan.com/"
        }
      }
    ]
  },
  gasReporter: {
    currency: 'USD',
    enabled: true
  }
};


///////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////
task("ccct", "Clean, Compile, Coverage, & Test the Greeter.sol").setAction(async () => {

  // Works!
  await hre.run("clean");
  await hre.run("compile");
  await hre.run("coverage");
  await hre.run("test");
});